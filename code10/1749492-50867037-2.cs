    builder.Entity<Entity1>(b =>
    {
        b.HasKey(e => e.Id);
        b.Property(e => e.Id).ValueGeneratedNever();
        b.OwnsOne<Entity2>(e => e.Metadata);
        b.HasOne<Entity2>(e => e.Metadata)
            .WithOne(e => e.Main)
            .HasForeignKey<Entity2>(e => e.Id);
        b.ToTable("Table_Entity1");
    });
    builder.Entity<Entity2>(b =>
    {
         b.HasKey(e => e.Id);
         b.ToTable("Table_Entity2");
    });
