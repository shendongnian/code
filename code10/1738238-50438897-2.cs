    public class StackOverflowContext : DbContext
    {
    	public DbSet<Table1> Table1 { get; set; }
    	public DbSet<Table2> Table2 { get; set; }
    	public DbSet<Table3> Table3 { get; set; }
    }
    
    [Table("Table1")]
    public class Table1
    {
    	public int Table1Id { get; set; }
    }
    
    [Table("Table2")]
    public class Table2
    {
    	public int Table2Id { get; set; }
    }
    
    [Table("Table3")]
    public class Table3
    {
        // Composite key of two keys
    	[Key, Column(Order = 1)]
    	public int Table1Id { get; set; }
    	[Key, Column(Order = 2)]
    	public int Table2Id { get; set; }
        
        // Navigation properties
    	public Table1 Table1 { get; set; }
    	public Table2 Table2 { get; set; }
    }
