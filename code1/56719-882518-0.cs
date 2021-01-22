    [XmlRoot("floors")]
    public class FloorCollection
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlElement("floor")]
        public Floor[] Floors { get; set; }
    
    }
