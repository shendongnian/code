    modelBuilder.Entity<SomeThing>().OwnsOne(st => st.Address,
          a =>
          {
                a.ToTable("SomeThingAddress");
          });
     modelBuilder.Entity<SomeThingElse>().OwnsOne(ste => ste.Address,
          a =>
          {
              a.ToTable("SomeThingElseAddress");
          });
