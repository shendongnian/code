    [XmlRoot("Root")]
    public class Test
    {
        public TypeData Type { get; set; }
    
        // ...
    }
    
    class TypeData
    {
        public string Data { get; set; }
    
        [XmlAttribute]
        public int Value { get; set; }
    }
