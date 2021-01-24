    public MyDbContext : DbContext
    {
        // The tables:
        public DbSet<Right> Rights {get; set;}
        public DbSet<User> Users {get; set;
        public DbSet<Seller> Sellers {get; set;}
        public DbSet<Buyer> Buyers {get; set;}
        ...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Buyers and Sellers are in separate tables:
            modelBuilder.Entity<Buyer>().ToTable("Buyers");
            modelBuilder.Entity<Seller>().ToTable("Sellers");
            // if you want you could name the User and Right tables
            // but that is not needed. Entity Framework already knows
            // they should be in separate tables
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
