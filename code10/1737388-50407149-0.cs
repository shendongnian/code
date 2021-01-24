    public class Datum
    {
        public string AI { get; set; }
        public int BatchId { get; set; }
        public int LogisticLevel { get; set; }
        public int ParentId { get; set; }
        public int State { get; set; }
        public int SyncState { get; set; }
        public int InternalID { get; set; }
        public object ModifyReason { get; set; }
        public DateTime AggregationDate { get; set; }
        public DateTime CommissioningDate { get; set; }
        public DateTime DecommissioningDate { get; set; }
        public int NumberOfChildren { get; set; }
        public int RejectCode { get; set; }
        public DateTime ShippingDate { get; set; }
        public int TotalNumberOfUnits { get; set; }
        public string CompanyPrefix { get; set; }
        public int FilterValue { get; set; }
        public int PackLevel { get; set; }
        public string ReferenceCode { get; set; }
        public int Schema { get; set; }
        public string SerialNumber { get; set; }
        public bool IsGood { get; set; }
        public List<object> Children { get; set; }
    }
    
    public class RootObject
    {
        public List<Datum> Data { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
    JsonConvert.DeserializeObject<RootObject>(
        "{\"Data\":[{\"AI\":\"(00)103002310000531111\",\"BatchId\":157,\"LogisticLevel\":7,\"ParentId\":-1,\"State\":1,\"SyncState\":-1,\"InternalID\":86996,\"ModifyReason\":null,\"AggregationDate\":\"1900-01-01T00:00:00\",\"CommissioningDate\":\"1900-01-01T00:00:00\",\"DecommissioningDate\":\"1900-01-01T00:00:00\",\"NumberOfChildren\":0,\"RejectCode\":-1,\"ShippingDate\":\"1900-01-01T00:00:00\",\"TotalNumberOfUnits\":1,\"CompanyPrefix\":\"030023\",\"FilterValue\":7,\"PackLevel\":1,\"ReferenceCode\":\"\",\"Schema\":1,\"SerialNumber\":\"1000053111\",\"IsGood\":true,\"Children\":[]}],\"Code\":10,\"Message\":\"Data retrieved\"}"
    
    ).Dump();
