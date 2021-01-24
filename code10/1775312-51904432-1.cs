    class DataContext : DbContext
    {
        // ctor omitted for brevity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(customer =>
            {
                customer.HasMany(entity => entity.Applications)
                    .WithOne(relatedEntity => relatedEntity.Customer)
                    .OnDelete(DeleteBehavior.Cascade);
                customer.HasOne(entity => entity.CurrentApplication)
                    .WithOne()
                    .HasForeignKey<Customer>(entity => entity.CurrentApplicationId);
            });
        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
