    modelBuilder.Entity<MyEntity>().Map(m =>
    {
      m.ToTable("MyEntities");
      m.MapInheritedProperties();
    }
