     [XmlRoot(ElementName = "size", Namespace = "http://www.example.com/ticketlayout")]
        public class Size
        {
            [XmlAttribute(AttributeName = "measure")]
            public string Measure { get; set; }
            [XmlText]
            public string Text { get; set; }
        }
    
        [XmlRoot(ElementName = "fontdefinition", Namespace = "http://www.example.com/ticketlayout")]
        public class Fontdefinition
        {
            [XmlElement(ElementName = "fontname", Namespace = "http://www.example.com/ticketlayout")]
            public string Fontname { get; set; }
            [XmlElement(ElementName = "size", Namespace = "http://www.example.com/ticketlayout")]
            public Size Size { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
        }
    
        [XmlRoot(ElementName = "ticketlayout", Namespace = "http://www.example.com/ticketlayout")]
        public class Ticketlayout
        {
            [XmlElement(ElementName = "fontdefinition", Namespace = "http://www.example.com/ticketlayout")]
            public Fontdefinition Fontdefinition { get; set; }
            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }
            [XmlAttribute(AttributeName = "logicalName")]
            public string LogicalName { get; set; }
            [XmlAttribute(AttributeName = "deviceCode")]
            public string DeviceCode { get; set; }
            [XmlAttribute(AttributeName = "measurement")]
            public string Measurement { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
            [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
            public string SchemaLocation { get; set; }
        }
