    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MyEntityType>().Property(k => k.Id).HasColumnName("CustomerId");
    // ...
    }
