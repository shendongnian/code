    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.ClrType == null)
            {
                continue;
            }
            // Set the table name mapping for the class
            entityType.Relational().TableName = ConvertToUpperCaseUnderscore(entityType.ClrType.Name);
            var props = entityType.GetProperties().ToList();
            foreach (var p in props)
            {
                // Set the column name mapping for the class
                p.Relational().ColumnName = ConvertToUpperCaseUnderscore(p.Name);
            }
        }
        base.OnModelCreating(modelBuilder);
    }
