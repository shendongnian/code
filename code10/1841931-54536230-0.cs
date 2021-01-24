    [XmlRoot(ElementName = "document")]
    public class Document
    {
        [XmlElement("body")]
        public XmlElement Body { get; set; }
    }
