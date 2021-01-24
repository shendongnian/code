    foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.ClrType.IsSubclassOf(typeof(Dto.Dto)))
                {
                    modelBuilder.Entity(entity.ClrType)
                        .HasKey(nameof(Dto.Dto.Id)).ForSqlServerIsClustered(false);
                    modelBuilder.Entity(entity.ClrType)
                        .Property(nameof(Dto.Dto.CreatedAt))
                        .HasDefaultValueSql("SYSUTCDATETIME()");
                    modelBuilder.Entity(entity.ClrType)
                        .Property(nameof(Dto.Dto.LastUpdate))
                        .HasComputedColumnSql("SYSUTCDATETIME()");
                    foreach (var prop in entity.GetProperties())
                    {
                        var attr = prop.PropertyInfo?.GetCustomAttribute<ClusteredAttribute>(true);
                        if (attr != null)
                        {
                            var index = entity.AddIndex(prop);
                            index.IsUnique = true;
                            index.SqlServer().IsClustered = true;
                        }
                    }
                }
            }
this if  if (entity.ClrType.IsSubclassOf(typeof(Dto.Dto))) is to discard quickly the tables created by ASP.net Core, so the changes are made only for my objects that inherit from Dto.
