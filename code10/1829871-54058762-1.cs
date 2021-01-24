    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<BaseTable>().Property(x => x.Created).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<BaseTable>().Property(x => x.Updated).HasDefaultValueSql("GETDATE()");
           //here is my composite key
           modelBuilder.Entity<Student>().HasKey(c => new { c.Key, c.Id });
     }
