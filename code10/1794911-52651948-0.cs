    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Added this line.
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<SURCH>()
            .Property(e => e.COST)
            .HasPrecision(38, 4);
    }
