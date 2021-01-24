    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coordinate>().HasKey(u => u.CoordinateKey);
        modelBuilder.Entity<Coordinate>().Property(c => c.CoordinateKey)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }
