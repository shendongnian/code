    public class RootObject
    {
        public List<Range> range { get; set; }
        public List<Friend> friends { get; set; }
    }
    public class Range
    {
        public int num { get; set; }
    }
    
    public class Friend
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    
