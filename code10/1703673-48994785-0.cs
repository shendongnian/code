    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<MyUser>().HasMany(u => u.Rooms);
       modelBuilder.Entity<PrivateUser>().HasMany(c => c.Users);
    }
