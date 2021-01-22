    [XmlRoot("Node", Namespace="http://flibble")]
    public class MyType {
        [XmlElement("chileNode")]
        public string Value { get; internal set; }
    }
