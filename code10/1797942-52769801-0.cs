    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Product>()
                    .HasMany(e => e.Parts)
                    .WithMany(e => e.Products)
                    .Map(m => m.ToTable("ProductParts").MapLeftKey("PartID").MapRightKey("ProductID"));
    }
