    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var class1Entity = modelBuilder.Entity<Class1>();
        class1Entity.OwnsOne(
                class1 => class1.NestedProp,
                nestedProp =>
                {
                    nestedProp.Property(p => p.NestedProp)
                          .HasColumnType("NUMERIC(38, 16)")
                          .HasColumnName("NestedPropValue"); // here you could add a custom name like I did or remove it and you get a generated one
                });
    }
