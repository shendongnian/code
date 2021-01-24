    public class Table1
    {
        public Guid Table1CoreId {get;set;}
        public string Name {get;set;}
    }
    public class Table2
    {
       Guid Table1CoreId {get;set;}
       int  Table2CoreId {get;set;}
    }
    
    public class Table3
    {
       Guid Table2CoreId {get;set;}
    }
    public class Table4
    {
       Guid Table2CoreId {get;set;}
    }
