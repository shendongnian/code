    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<RecordType>().HasIndex(u => u.RecordType).IsUnique();
    }
