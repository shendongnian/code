    public class Document
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlText]
        public string Name { get; set; }
    }
