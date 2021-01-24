    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<YourEntity>().Property(s => s.RowVersion).IsConcurrencyToken();
        //modelBuilder.Entity<YourEntity>().Property(s => s.RowVersion).IsRowVersion(); // in EF6 or EF Core
        base.OnModelCreating(modelBuilder);
    }
