		public class TestDbContext : DbContext
		{
			public TestDbContext() : base("MyConnectionString")
			{
				Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestDbContext, Migrations.Configuration>());
				Configuration.LazyLoadingEnabled = true;
			}
			public IDbSet<InvoiceStatus> InvoiceStatus { get; set; }
			public IDbSet<InvoiceSample> InvoiceSamples { get; set; }
			protected override void OnModelCreating(DbModelBuilder modelBuilder)
			{
			}
		}
