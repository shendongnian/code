    public class Container
    {
        public string name { get; set; }
        public Inner Inner { get; set; }
    }
    
    public class Inner
    {
        public string text { get; set; }
        public List<Inner> MoreInners { get; set; }
    }
