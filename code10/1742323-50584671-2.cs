        public class TenantDbContext : DbContext
        {
            public TenantDbContext () : Base("name=yourConnString") { }
            public DbSet<Product> Products { get; set; }
            public DbSet<Sales> Sales { get; set; }
        }
