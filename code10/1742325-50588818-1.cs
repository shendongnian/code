     public class TenantContext : DbContext
     {
        public TenantContext(string connection, Tenanat tenanat)
            : base(connection)
        {
            //create DB for tenant
            Database.CreateIfNotExists();
            //create user for the new Db
            string sql = "CREATE LOGIN \"" + tenanat.Email + "\" WITH PASSWORD = '" + tenanat.Password + "'; USE " + tenanat.Name + "; CREATE USER \"" + tenanat.Email + "\" FOR LOGIN \"" + tenanat.Email + "\" WITH DEFAULT_SCHEMA = dbo;";
            Database.ExecuteSqlCommand(sql);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
       }}
