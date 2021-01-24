    public MyDbContext : DbContext
    {
        public DbSet<Listing> Listings {get; set;}
        public DbSet<Category> Categories {get; set;}
    }
