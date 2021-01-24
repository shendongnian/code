    public class Table1{
        public int Id{get; set;} //Primary key by convention
        [ForeignKey("Table2")]
        public int Table2Id{get; set;}
        public virtual Table2 Table2{get; set;}
    }
    
    public class Table2{
        public int Id{get; set;} //Primary key by convention
        public virtual Table1 Table1{get; set;}
    }
