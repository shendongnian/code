    public class Id
    {
        public string _type { get; set; }
        public string Class { get; set; }
        public string RollId { get; set; }
    }
    
    public class Datum
    {
        public string _type { get; set; }
        public string Class { get; set; }
        public Id Id { get; set; }
        public object Data { get; set; }
    }
    
    public class Elements
    {
        public string _type { get; set; }
        public List<Datum> _data { get; set; }
    }
    
    public class Root
    {
        public string _type { get; set; }
        public string Class { get; set; }
        public Elements Elements { get; set; }
    }
    
    public class RootObject
    {
        public int encoding_version { get; set; }
        public Root root { get; set; }
    }
