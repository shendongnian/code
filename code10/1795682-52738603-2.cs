    if (Database.IsSqlite())
    {
    	var timestampProperties = modelBuilder.Model
    		.GetEntityTypes()
    		.SelectMany(t => t.GetProperties())
    		.Where(p => p.ClrType == typeof(byte[])
    			&& p.ValueGenerated == ValueGenerated.OnAddOrUpdate
    			&& p.IsConcurrencyToken);
    
    	foreach (var property in timestampProperties)
    	{
    		property.SetValueConverter(new SqliteTimestampConverter());
    		property.Relational().DefaultValueSql = "CURRENT_TIMESTAMP";
    	}
    }
