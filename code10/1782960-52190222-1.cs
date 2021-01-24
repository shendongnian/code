    [XmlRoot("MyRoot")]
    public class MyRoot
    {
        [XmlElement("Table")]
        public List<Table> Tables { get; set; }
    }
    public class Table
    {
        [XmlAttribute("schema")]
        public string Schema { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("caption")]
        public string Caption { get; set; }
        [XmlElement("Column")]
        public List<Column> Columns { get; set; }
        [XmlElement("ForeignKey")]
        public List<ForeignKey> ForeignKeys { get; set; }
    }
    public class Column
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("alias")]
        public string Alias { get; set; }
        [XmlAttribute("isprimarykey")]
        public string IsPrimaryKey { get; set; }
    }
    public class ForeignKey
    {
        [XmlAttribute("pkSchema")]
        public string PkSchema { get; set; }
        [XmlAttribute("pkTable")]
        public string PkTable { get; set; }
        [XmlAttribute("fkSchema")]
        public string FkSchema { get; set; }
        [XmlAttribute("fkTable")]
        public string FkTable { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("ForeignKeyCol")]
        public ForeignKeyCol ForeignKeyCol { get; set; }
    }
    public class ForeignKeyCol
    {
        [XmlAttribute("pkCol")]
        public string PkCol { get; set; }
        [XmlAttribute("fkCol")]
        public string FkCol { get; set; }
    }
