    private void SoftDelete(DbEntityEntry entry)
    {
    	Type entryEntityType = entry.Entity.GetType();
    
    	string tableName = GetTableName(entryEntityType);
    	string primaryKeyName = GetPrimaryKeyName(entryEntityType);
    
    	string sql =
    		string.Format(
    			"UPDATE {0} SET IsDeleted = true WHERE {1} = @id",
    				tableName, primaryKeyName);
    
    	Database.ExecuteSqlCommand(
    		sql,
    		new SqlParameter("@id", entry.OriginalValues[primaryKeyName]));
    
    	// prevent hard delete            
    	entry.State = EntityState.Detached;
    }
