    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Shape>().HasKey(x=>x.Id);
        modelBuilder.Entity<ShapeColor>(x =>
        {
            // x.HasKey(p => p.Id);
            x.Property(p => p.ShapeId).IsRequired();
            x.HasOne<Shape>().WithMany().HasForeignKey(y => y.ShapeId);
        });
        base.OnModelCreating(modelBuilder);
    }
