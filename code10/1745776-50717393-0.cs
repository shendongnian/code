    public class Table
    {
        public int Id{get;set;}
        public string Name {get;set;}
        public ICollection<Column> Columns {get;set;}
        public ICollection<Row> Rows {get;set;}
    }
    
    public class Row
    {
        public int Id{get;set;}
        public ICollection<ColumnValueBase> Values {get;set;}
    }
    
    public abstract class Column
    {
        public int Id {get;set;}
        public Column Column {get;set;}
    }
    
    public abstract class ColumnValue
    {
        public int Id {get;set;}
    }
    
    public class IntColumn : Column
    {
        public IntColumnValue IntValue {get;set;}
    }
    
    // other types of columns and values
    
    public class TablesContext : DbContext
    {
        public DbSet<Table> Tables {get;set;}
    }
