    public class RootObject
    {
        public ResultObject results { get; set; }
    }
    
    public class ResultObject
    {
        public Dictionary<string, RecordObject> records { get; set; }
    }
    
    public class RecordObject
    {
        public string name { get; set; }
        public string description { get; set; }
    }
