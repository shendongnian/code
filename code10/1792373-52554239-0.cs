    public class Amount
    {
        public int tid { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
    }
    
    public class RootObject
    {
        public List<Amount> amounts { get; set; }
        public int status { get; set; }
        public int errorCode { get; set; }
    }
