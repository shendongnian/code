    public class Company
    {
        public List<Tables> Tables { get; set; }
    }
    // As you said Agri type ignored for now
    public class Tables
    {
        public Table Table { get; set; } // Use collection if Table can be more the one
        [XmlElement("Tables")]
        public Tables InnerTables { get; set; }
    }
    public class Table
    {
        [XmlAttribute]
        public string Id { get; set; }
    }
