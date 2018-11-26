/*
 * Copyright (c) 2018 Demerzel Solutions Limited
 * This file is part of the Nethermind library.
 *
 * The Nethermind library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * The Nethermind library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using Nethermind.Blockchain;
using Nethermind.Config;
using Nethermind.Core;
using Nethermind.Core.Extensions;
using Nethermind.Core.Logging;
using Nethermind.Core.Test.Builders;
using Nethermind.Evm.Tracing;
using Nethermind.JsonRpc.DataModel;
using Nethermind.JsonRpc.DataModel.Converters;
using Nethermind.JsonRpc.DataModel.Trace;
using Nethermind.JsonRpc.Module;
using NSubstitute;
using NUnit.Framework;

namespace Nethermind.JsonRpc.Test.DataModel
{
    [TestFixture]
    public class ParityTraceActionSerializationTests : SerializationTestBase
    {
        [Test]
        public void Can_serialize()
        {
            ParityTraceAction action = new ParityTraceAction();
            action.From = TestObject.AddressA;
            action.Gas = 12345;
            action.Input = new byte[] {6, 7, 8, 9, 0};
            action.To = TestObject.AddressB;
            action.Value = 24680;
            action.CallType = "call";
            action.TraceAddress = new int[] {1, 3, 5, 7};
            
            TestOneWaySerialization(action, "{\"callType\":\"call\",\"from\":\"0xb7705ae4c6f81b66cdb323c65f4e8133690fc099\",\"gas\":12345,\"input\":\"0x0607080900\",\"to\":\"0x942921b14f1b1c385cd7e0cc2ef7abe5598c8358\",\"value\":\"0x6068\"}");
        }
        
        [Test]
        public void Can_serialize_nulls()
        {
            ParityTraceAction action = new ParityTraceAction();
            
            TestOneWaySerialization(action, "{\"callType\":null,\"from\":null,\"gas\":0,\"input\":null,\"to\":null,\"value\":\"0x0\"}");
        }
    }
}