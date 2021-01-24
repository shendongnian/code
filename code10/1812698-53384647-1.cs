    public class Company
    {
        public Company()
        {
            this.Tables = new CompanyTables();
        }
    
        [XmlElement]
        public CompanyTables Tables { get; set; }
    }
    
    public class CompanyTables
    {
        public CompanyTables()
        {
            this.Agri = new Agri();
        }
    
        [XmlElement]
        public TablesArr[] Tables { get; set; }
    
        [XmlElement]
        public Agri Agri { get; set; }
    }
    
    public class Agri
    {
        public Agri() { }
    
        [XmlElementAttribute("Tables")]
        public TablesArr[] Tables { get; set; }
    }
    
    public class TablesArr
    {
        public TablesArr() { }
    
        [XmlElementAttribute("Table")]
        public Table[] Tables { get; set; }
    }
    
    public class Table
    {
        public Table() { }
    
        [XmlAttribute("Id")]
        public int Id { get; set; }
    }
