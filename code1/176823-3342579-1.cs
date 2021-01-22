    [XmlRoot(ElementName = "FIBEX", Namespace = "http://www.asam.net/xml/fbx")]
    public class FIBEX
    {
        [XmlElement("CODING", Namespace = "http://www.asam.net/xml/fbx")]
        public FIBEXCoding Coding { get; set; }
    }
    public class FIBEXCoding
    {
        [XmlElement("SHORT-NAME", Namespace = "http://www.asam.net/xml")]
        public string ShortName { get; set; }
        [XmlElement("DESC", Namespace = "http://www.asam.net/xml")]
        public string ShortDescription { get; set; }
        [XmlElement("CODED-TYPE", Namespace = "http://www.asam.net/xml")]
        public FIBEXCodedType Codedtype { get; set; }
    }
    public class FIBEXCodedType
    {
        [XmlAttribute("BASE-DATA-TYPE", 
            Namespace = "http://www.asam.net/xml",
            Form=XmlSchemaForm.Qualified)]
        public string BaseDataType { get; set; }
        [XmlAttribute("CATEGORY")]
        public string Category { get; set; }
        [XmlAttribute("ENCODING")]
        public string Encoding { get; set; }
        [XmlElement("BIT-LENGTH", Namespace = "http://www.asam.net/xml")]
        public int BitLength { get; set; }
    }
