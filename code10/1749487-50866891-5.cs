    builder.Entity<Entity1>(b =>
    {
        b.HasKey(e1 => e1.Id);
        b.OwnsOne(e1 => e1.Metadata).ToTable("Table_Entity2");
        b.ToTable("Table_Entity1");
    });
