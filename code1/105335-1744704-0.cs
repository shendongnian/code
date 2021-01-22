    public class Root
    {
        [XmlElement("Object")]
        public List<SomeOtherObject> Objects { get; set; }
    }
    
    public class SomeOtherObject
    {
        [XmlElement("referenceName")]
        public string Name { get; set; }
        [XmlElement("query")]
        public string Query { get; set; }
    }
