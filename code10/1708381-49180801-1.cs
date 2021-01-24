    public class Result
    {
        public List<List<object>> XETHZUSD { get; set; }
        public int last { get; set; }
    }
    
    public class RootObject
    {
        public List<object> error { get; set; }
        public Result result { get; set; }
    }
