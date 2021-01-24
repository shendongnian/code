    [XmlRoot(ElementName = "row")]
    public class Row
    {
        [XmlElement(ElementName = "d")]
        public List<string> D { get; set; }
    }
    [XmlRoot(ElementName = "table")]
    public class Table
    {
        [XmlElement(ElementName = "label")]
        public Row Label { get; set; }
        [XmlElement(ElementName = "classname")]
        public Row Classname { get; set; }
        [XmlElement(ElementName = "datatype")]
        public Row Datatype { get; set; }
        [XmlElement(ElementName = "row")]
        public List<Row> Row { get; set; }
    }
