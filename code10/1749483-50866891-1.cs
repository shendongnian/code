    builder.Entity<Entity1>(b =>
    {
        b.HasKey(e1 => e1.Id);
        b.OwnsOne(e1 => e1.Metadata, md => {
            // I think the example on the Microsoft Doc is wrong but need to verify.
            md.ToTable("Table_Entity2");
        });
        b.ToTable("Table_Entity1");
    });
