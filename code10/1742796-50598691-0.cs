    modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language", "common");
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar");
            });
