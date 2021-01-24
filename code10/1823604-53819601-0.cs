    [Serializable()]
    [XmlRoot("Message")]
    public class Message
    {
        [XmlElement("Foo")]
        public Foo Foo { get; set; }
    }
    [Serializable()]
    public class Foo
    {
        [XmlElement("Bar")]
        public string Bar { get; set; }
        [XmlElement("Baz")]
        public string Baz { get; set; }
        [XmlElement("Qux")]
        public string Qux { get; set; }
    }
