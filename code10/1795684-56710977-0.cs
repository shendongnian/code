    var connection = new SqliteConnection("DataSource=:memory:");
    
    var options = new DbContextOptionsBuilder<ActiveContext>()
    			   .UseSqlite(connection)
    			   .Options;
    
    var ctx = new ActiveContext(options);
    
    if (connection.State != System.Data.ConnectionState.Open)
    {
    	connection.Open();
    
    	ctx.Database.EnsureCreated();
    
    	var tables = ctx.Model.GetEntityTypes();
    
    	foreach (var table in tables)
    	{
    		var props = table.GetProperties()
    						.Where(p => p.ClrType == typeof(byte[])
    						&& p.ValueGenerated == Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAddOrUpdate
    						&& p.IsConcurrencyToken);
    
    		var tableName = table.Relational().TableName;
    
    		foreach (var field in props)
    		{
    			string[] SQLs = new string[] {
    				$@"CREATE TRIGGER Set{tableName}_{field.Name}OnUpdate
    				AFTER UPDATE ON {tableName}
    				BEGIN
    					UPDATE {tableName}
    					SET RowVersion = randomblob(8)
    					WHERE rowid = NEW.rowid;
    				END
    				",
    				$@"CREATE TRIGGER Set{tableName}_{field.Name}OnInsert
    				AFTER INSERT ON {tableName}
    				BEGIN
    					UPDATE {tableName}
    					SET RowVersion = randomblob(8)
    					WHERE rowid = NEW.rowid;
    				END
    				"
    			};
    
    			foreach (var sql in SQLs)
    			{
    				using (var command = connection.CreateCommand())
    				{
    					command.CommandText = sql;
    					command.ExecuteNonQuery();
    				}
    			}
    		}
    	}
    }
