    public class Meta {
        public int count { get; set; }
    }
    
    public class All {
        public int f1 { get; set; }
        public int f2 { get; set; }
        public double f3 { get; set; }
    }
    
    public class Data {
        public All all { get; set; }
    }
    
    public class MyType {
        public string status { get; set; }
        public Meta meta { get; set; }
        public IDictionary<string, IList<Data>> data { get; set; }
    }
    
