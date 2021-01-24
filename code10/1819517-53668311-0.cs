    public class Field
    {
        public string Description { get; set; }
        public string Value { get; set; }
    }
    
    public class Info
    {
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string Detail3 { get; set; }
        public List<Field> Fields { get; set; }
    }
    
    public class RootObject
    {
        public List<Info> Info { get; set; }
    }
