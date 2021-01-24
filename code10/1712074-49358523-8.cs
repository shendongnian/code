    public MyDbContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Post> Posts {get; set;}
        public DbSet<Reaction> Reactions {get; set;}
    }
