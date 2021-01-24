    protected override void OnModelCreating(Modelbuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
       .HasMany(c => c.Category)
       .WithOne(e => e.Category).
       .OnDelete(DeleteBehavior.Cascade );
    }
