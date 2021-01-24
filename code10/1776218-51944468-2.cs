    class ManyDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Enumeration> Enumerations { get; set; }
		public DbSet<Part> Parts { get; set; }
		public DbSet<Junction> Junctions {get; set;}
	}
