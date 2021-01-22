    [XmlRoot("components", Namespace = XmlNamespace)]
    [XmlType("components", Namespace = XmlNamespace)]
    public class ComponentsMessage
    {
        public const string XmlNamespace = "http://www.example.com/nis/componentsync";
        [XmlElement("component")]
        public NetworkComponent[] Components { get; set; }
    }
