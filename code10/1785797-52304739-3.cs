    modelBuilder.Entity<MyEntity>().Map(m =>
    {
      m.MapInheritedProperties();
      m.ToTable("MyEntities");
    }
