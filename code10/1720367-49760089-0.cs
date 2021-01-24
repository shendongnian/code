    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {    
      modelBuilder.Entity<MyEntity>(b =>
      {
        b.HasKey(e => e.Identifier);
        b.Property(e => e.Identifier).ValueGeneratedOnAdd();
      }
    }
