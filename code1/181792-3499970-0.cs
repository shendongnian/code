    [XmlRoot(Namespace = "http://schemas.fabrikam.com/mynamespace")]
    [XmlType(Namespace = "http://schemas.fabrikam.com/mynamespace")]
    public class MyObject
    {
        [XmlElement(Namespace = "http://schemas.fabrikam.com/anothernamespace")]
        public string MyElement { get; set; }
    
        [XmlAttribute(Namespace = "http://schemas.fabrikam.com/yetanothernamespace")]
        public string MyAttribute { get; set; }
    }
