    modelBuilder.Entity<SomeThing>().OwnsOne(st => st.Address,
         a =>
         {
              a.Property(p => p.Street).HasColumnName("Street");
              a.Property(p => p.City).HasColumnName("City");
         });
    modelBuilder.Entity<SomeThingElse>().OwnsOne(ste => ste.Address,
         a =>
         {
              a.Property(p => p.Street).HasColumnName("Street");
              a.Property(p => p.City).HasColumnName("City");
         });
