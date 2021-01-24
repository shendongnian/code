    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<YourEntity>().Property(s => s.RowVersion).IsRowVersion();
        base.OnModelCreating(modelBuilder);
    }
