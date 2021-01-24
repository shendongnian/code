    public class c10
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    
    public class c201
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    
    public class c300
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    
    public class NoOfRecords
    {
        public c10 { get; set; }
        public c201 { get; set; }
        public c300 { get; set; }
    }
    
    public class PagesData
    {
        public string state { get; set; }
        public string idNo { get; set; }
        public NoOfRecords noOfRecords { get; set; }
    }
    
    public class RootObject
    {
        public int scriptVersion { get; set; }
        public List<PagesData> pagesData { get; set; }
    }
