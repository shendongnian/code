    modelBuilder.Entity<Content>()
           .HasMany<State>(a => a.States)
           .WithMany()
           .Map(a =>
           {
               a.ToTable("Content_State", "MySchema");
               a.MapLeftKey("ContentId");
               a.MapRightKey("StateID");
           });
