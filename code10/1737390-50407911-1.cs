                string json= "{\"Data\":[{\"AI\":\"(00)103002310000531111\",\"BatchId\":157,\"LogisticLevel\":7,\"ParentId\":-1,\"State\":1,\"SyncState\":-1,\"InternalID\":86996,\"ModifyReason\":null,\"AggregationDate\":\"1900-01-01T00:00:00\",\"CommissioningDate\":\"1900-01-01T00:00:00\",\"DecommissioningDate\":\"1900-01-01T00:00:00\",\"NumberOfChildren\":0,\"RejectCode\":-1,\"ShippingDate\":\"1900-01-01T00:00:00\",\"TotalNumberOfUnits\":1,\"CompanyPrefix\":\"030023\",\"FilterValue\":7,\"PackLevel\":1,\"ReferenceCode\":\"\",\"Schema\":1,\"SerialNumber\":\"1000053111\",\"IsGood\":true,\"Children\":[]}],\"Code\":10,\"Message\":\"Data retrieved\"}";
                dynamic bsObj = JsonConvert.DeserializeObject<dynamic>(json);
                Console.WriteLine(bsObj.ToString());
                Console.WriteLine(bsObj.Data[0].BatchId.ToString());  //157
                Console.WriteLine(bsObj.Code.ToString()); // 10
                Console.WriteLine(bsObj.Message.ToString()); // Data retrieved
