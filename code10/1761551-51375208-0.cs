    public class LoginResult
    {
        public string sctoken { set; get; }
        public List<Maps> tms { set; get; }
    }
    
    public class Maps
    {
        public string name { get; set; }
        public string url { get; set; }
    }
