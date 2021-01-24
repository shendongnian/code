    public static void LowercaseRelationalTableAndPropertyNames(this ModelBuilder modelBuilder) 
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.Relational().TableName = entity.Relational().TableName.ToLowerInvariant();
            foreach (var property in entity.GetProperties())
            {
                property.Relational().ColumnName = property.Relational().ColumnName.ToLowerInvariant();
            }
        }
    }
