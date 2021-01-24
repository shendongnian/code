    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<YourEntity>().Property(s => s.RowVersion).IsConcurrencyToken();
        base.OnModelCreating(modelBuilder);
    }
