    [XmlRoot("Person")]
    public class Person
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Country")]
        public string Country { get; set; }
        [XmlAttribute("xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
        [XmlAttribute("xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
    }
