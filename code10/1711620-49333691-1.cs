    public class Data
    {
        public string type { get; set; }
        public string name { get; set; }
        public int steam_appid { get; set; }
        public int required_age { get; set; }
        public bool is_free { get; set; }
    }
    
    public class SomeClass
    {
        public bool success { get; set; }
        public Data data { get; set; }
    }
 
