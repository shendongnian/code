    public class ObjetWSResult
    {
        public List<object> result { get; set; }
        public string msg { get; set; }
    }
    
    public class RootObject
    {
        public string success { get; set; }
        public ObjetWSResult objetWSResult { get; set; }
    }
