      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Student>().Property(x => x.Created).HasDefaultValueSql("GETDATE()");
         modelBuilder.Entity<Student>().Property(x => x.Updated).HasDefaultValueSql("GETDATE()");
      }
