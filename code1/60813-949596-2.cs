    [XmlRoot("content")]
    public class Content {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("p")]
        public string Description { get; set; }
        [XmlElement("form")]
        public List<ContentForm> Forms { get; set; }
    }    
    public class ContentForm {
        [XmlAttribute("idCode")]
        public string Id { get; set; }
        [XmlAttribute("query")]
        public string Query { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
    }
