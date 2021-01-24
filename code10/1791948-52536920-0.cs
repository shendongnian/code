    public class Size
    {
        public string value { get; set; }
    }
    
    public class Alignment
    {
        public string value { get; set; }
    }
    
    public class Object
    {
        public string value { get; set; }
    }
    
    public class Name
    {
        public string value { get; set; }
    }
    
    public class View
    {
        public Alignment alignment { get; set; }
        public bool IND { get; set; }
        public Object @object { get; set; }
        public Name name { get; set; }
    }
    
    public class RootObject
    {
        public Size size { get; set; }
        public View view { get; set; }
    }
