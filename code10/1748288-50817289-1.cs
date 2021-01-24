    class MyContext : DbContext
    {
        public DbSet<YourEntity> YourEntities{ get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YourEntity>()
                .Property(b => b.Created)
                .HasDefaultValueSql("getdate()");
        }
    }
