    builder.Entity<Entity1>(b =>
    {
        b.HasKey(e1 => e1.Id);
        b.OwnsOne(e1 => e1.Metadata, md => {
            // I think the example on the Microsoft Doc is wrong but need to verify.
            // I opened an issue here: 
            //   https://github.com/aspnet/EntityFramework.Docs/issues/772
            md.ToTable("Table_Entity2");
        });
        b.ToTable("Table_Entity1");
    });
