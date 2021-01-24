    public partial class MyContext : DbContext
    {
    	public MyContext(DbContextOptions<MyContext> options)
    		: base(options)
    	{
    	}
    
    	protected override void OnModelCreating(ModelBuilder modelBuilder)
    	{
    		OnModelCreatingInternal(modelBuilder);
    		modelBuilder.Entity<Blog>().Property<string>("TenantId").HasField("
    		modelBuilder.Entity<Blog>().HasQueryFilter(b => EF.Property<string>(b, "TenantId") == _tenantId);
    	}
    }
