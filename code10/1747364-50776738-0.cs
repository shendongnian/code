    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ...
        modelBuilder.Entity<LocalEvent>()
            .Property(e => e.DateCreated)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
        // ...
    }
