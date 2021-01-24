    public class Company
    {
        public CompanyTables Tables { get; set; }
    }
    public class CompanyTables
    {
        [XmlElement]
        public List<Tables> Tables { get; set; }
        public List<Tables> Agri { get; set; }
    }
    public class Tables
    {
        [XmlElement]
        public List<Table> Table { get; set; }
    }
    public class Table
    {
        [XmlAttribute]
        public int Id { get; set; }
    }
