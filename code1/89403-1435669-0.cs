    [XmlRoot(ElementName = "records",
             Namespace = "http://www.foo.com/xml/records/1.1")]
    public class Records
    {
        [XmlElement(Type = typeof(Record),
                    ElementName = "record",
                    Namespace = "http://www.foo.com/xml/records/1.0")]
        [XmlElement(Type = typeof(Record11),
                    ElementName = "record",
                    Namespace = "http://www.foo.com/xml/records/1.1")]
        public List<Record> Records { get; set; }
    }
