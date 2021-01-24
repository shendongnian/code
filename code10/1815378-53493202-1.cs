    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
          base.OnModelCreating(modelBuilder);
          modelBuilder.Entity<YourEntity>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
     }
