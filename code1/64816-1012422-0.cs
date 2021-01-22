    class Document {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlText]
        public string Name { get; set; }
    }
    
    
    public class _Filter    
    {
        [XmlElement("Times")]    
        public _Times Times;    
        [XmlElement("Document")]    
        public Document Document;    
    }
