    modelBuilder.Entity(entity.ClrType)
                    .Property(nameof(Dto.Dto.CreatedAt))
                    .HasDefaultValueSql("SYSUTCDATETIME()");
    modelBuilder.Entity(entity.ClrType)
                    .Property(nameof(Dto.Dto.LastUpdate))
                    .HasComputedColumnSql("SYSUTCDATETIME()");
