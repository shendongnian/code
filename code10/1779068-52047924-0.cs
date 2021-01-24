    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "ShiftID")]
        public string ShiftID { get; set; }
        [XmlElement(ElementName = "EmployeeID")]
        public string EmployeeID { get; set; }
    }
    
    [XmlRoot(ElementName = "Rows")]
    public class Rows
    {
        [XmlElement(ElementName = "Row")]
        public List<Row> Row { get; set; }
    }
    
    [XmlRoot(ElementName = "Table")]
    public class Table
    {
        [XmlElement(ElementName = "Rows")]
        public Rows Rows { get; set; }
        [XmlAttribute(AttributeName = "SourceQuery")]
        public string SourceQuery { get; set; }
    }
    
    [XmlRoot(ElementName = "Tables")]
    public class Tables
    {
        [XmlElement(ElementName = "Table")]
        public Table Table { get; set; }
    }
