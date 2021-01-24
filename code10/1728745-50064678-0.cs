    [XmlRoot("parent", Namespace = "urn:place-com:spec.2004", IsNullable = false)]
    public class Parent
    {
        [XmlElement("childA", Namespace = "")]
        public string ChildA { get; set; }
    
        [XmlElement("childB", Namespace = "")]
        public string ChildB { get; set; }
    }
