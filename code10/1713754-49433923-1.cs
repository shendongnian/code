    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var class1Entity = modelBuilder.Entity<Class1>();
        class1Entity.HasOne(p => p.NestedProp);
    
        var nestedPropEntity = modelBuilder.Entity<NestedProp>();
        nestedPropEntity.Property(p => p.Prop1)
            .HasPrecision(38,16);
    }
