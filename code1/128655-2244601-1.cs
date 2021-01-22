    [XmlRoot("components", Namespace = XmlNamespace)]
    [XmlType("components", Namespace = XmlNamespace)]
    public class ComponentsMessage
    {
        public const string XmlNamespace = "http://www.xxx.com/nis/componentsync";
        [XmlElement("component")]
        public NetworkComponent[] Components { get; set; }
    }
