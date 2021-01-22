    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ComplexType<ProductID>()
                   .Property(p=>p.ShortDescription)
                   .HasColumnName("ShortDescription")
                   .Property(p=>p.UserName)
                   .HasColumnName("UserName");
    }
