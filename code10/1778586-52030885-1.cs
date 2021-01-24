    public class Lookup
    {
        public string SerialNumber { get; set; }
        public string id { get; set; }
    }
    public class Value
    {
        public Lookup fields { get; set; }
    }
    public class RootObject
    {
        public List<Value> value { get; set; }
    }
