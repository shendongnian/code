    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<Model>()
        .Property(c => c.AnotherId )
        .UseSqlServerIdentityColumn();
    }
