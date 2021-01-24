    public class Table
    {
        public string ServerName { get; set; }
        public string TaskName { get; set; }
        public string SchemaName { get; set; }
        public string TableName { get; set; }
        public string DateReload { get; set; }
    }
    
    public class RootObject
    {
        public List<Table> Tables { get; set; }
    }
