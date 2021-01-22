    public class Foo
    {
        public string Name { get; set; }
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public XmlElement Any {get;set;}
    }
