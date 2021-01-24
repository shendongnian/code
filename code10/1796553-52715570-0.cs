    [XmlRoot(nameof(Trias), Namespace = "http://www.vdv.de/trias")]
    public class Trias
    {
    
        [XmlAttribute("version")]
        public string Version { get; set; }
    
        [XmlAttribute("xmlns")]
        public string Xmlns { get; set; }
    
        [XmlAttribute(Namespace = "http://www.siri.org.uk/siri")]
        public string Siri { get; set; }
    }
