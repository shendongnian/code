    [XmlRoot(ElementName = "City", Namespace = "http://tempuri.org/")]
        public class City
        {
            [XmlElement(ElementName = "string", Namespace = "http://tempuri.org/")]
            public List<string> String { get; set; }
        }
    
        [XmlRoot(ElementName = "ServiceAreas", Namespace = "http://tempuri.org/")]
        public class ServiceAreas
        {
            [XmlElement(ElementName = "City", Namespace = "http://tempuri.org/")]
            public City City { get; set; }
        }
    
        [XmlRoot(ElementName = "ArrayOfServiceAreas", Namespace = "http://tempuri.org/")]
        public class ArrayOfServiceAreas
        {
            [XmlElement(ElementName = "ServiceAreas", Namespace = "http://tempuri.org/")]
            public ServiceAreas ServiceAreas { get; set; }
            [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsd { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }
        }
