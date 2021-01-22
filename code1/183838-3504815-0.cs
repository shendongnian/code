    protected override void OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(product => product.Price).Precision = 10;
        modelBuilder.Entity<Product>().Property(product => product.Price).Scale = 2;
    }
