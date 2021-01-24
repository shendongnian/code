        modelBuilder.Entity<Model of table>(entity =>
            {
                entity.HasKey(e => e.{Unique column});
                entity.ToTable("Table's Name");
            }
        )
