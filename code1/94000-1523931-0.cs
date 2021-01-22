    [XmlType("file"), XmlRoot("file")]
    public class File {
        [XmlAttribute("name")]
        public string Name {get;set;}
        [XmlElement("ref")]
        public List<string> References {get;set;}
        public File() {References = new List<string>();}
    }
