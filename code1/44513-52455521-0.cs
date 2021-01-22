    class MyContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(b => b.Created)
                .HasDefaultValueSql("getdate()");
        }
    }
