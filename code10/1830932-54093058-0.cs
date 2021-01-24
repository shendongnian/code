    public class OtherGenericProperties
    {
        [XmlElement("Data")]
        public string Data { get; set; }
    }
    [XmlRoot("documents")]
    public class Documents
    {
        [XmlElement("document")]
        public Document Document { get; set; }
    }
    public class Document 
    {
        [XmlElement("Keys")] // this is used so the destination name can change in the future
        public Keys Keys { get; set; }
        [XmlElement("otherGenericProperties")]
        public OtherGenericProperties OtherGenericProperties { get; set; }
        [XmlElement("Repeat")]   // This does not work 
        public List<Repeat> ListRepeat { get; set; }
    }
    public class Keys
    {
        [XmlElement("drawer")]
        public string Drawer { get; set; }
        [XmlElement("somedata")]
        public string SomeData { get; set; }
    }
    public class Repeat
    {
        [XmlElement("FileInfo")]
        public FileInfo FileInfo { get; set; }
    }
    public class FileInfo
    {
        [XmlAttribute("mimeType")]
        public string MimeType { get; set; }
        [XmlAttribute("HREF")]
        public string Href { get; set; }
    }
