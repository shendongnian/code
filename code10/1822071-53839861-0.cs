    class SOContext : DbContext
    {
    	public DbSet<InterfaceType> InterfaceTypes { get; set; }
    	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    	{
    		var conn_string = @"Server=(localdb)\mssqllocaldb;Database=Interfaces;Trusted_Connection=Yes;";
    		optionsBuilder.UseSqlServer(conn_string);
    	}
    }
    
    [Table("InterfaceType", Schema = "Control")]
    public class InterfaceType
    {
    	[DatabaseGenerated(DatabaseGeneratedOption.None), Key]
    	public byte InterfaceTypeId { get; set; }
    	public string Description { get; set; }
    	public override string ToString() =>
    		$"Id: {InterfaceTypeId} | Description: {Description}";
    }
    
    // Output:
    // Id: 1 | Description: Desc1
    // Id: 2 | Description: Desc2
