    [XmlRoot(ElementName = "root")]
    public class Root
    {
        [XmlElement(ElementName = "record")]
        public List<Record> records { get; set; }
    }
    public class Record
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "NAME")]
        public string Name { get; set; }
    }
