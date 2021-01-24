    public class Table1{
        public int Id{get; set;} //Primary key by convention
        [ForeignKey("Table2")]
        public int Table2Id{get; set;}
        public Table2 Table2{get; set;}
    }
    
    public class Table2{
        public int Id{get; set;} //Primary key by convention
        public ICollection<Table1> Table1s{get; set;}
    }
