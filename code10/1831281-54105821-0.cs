    public partial class FooBarDbContext : DbContext
    {
        public FooBarDbContext() : base("name=Model1")
           => Database.SetInitializer<FooBarDbContext>(null);
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           //Configurations for Bundle class
           modelBuilder.Entity<Bundle>()
                    .ToTable("PL_Bundle")
            .HasKey(e => e.BundleID);
            .Property(e => e.Designation).HasMaxLength(200);
    
            modelBuilder.ApplyAllConfigurations();
            base.OnModelCreating(modelBuilder);
        }
    
        public DbSet<User> User { get; set; }
        public DbSet<Bundle> Bundles { get; set; }
        // [...]
    }
