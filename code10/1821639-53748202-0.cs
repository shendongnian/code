    private IEnumerable<T> GetDbSetByTableName<T>(string tableName)
    {
    	System.Reflection.PropertyInfo[] properties = typeof(ClearGUIEntities).GetProperties();
    	var prop = properties.FirstOrDefault(p => p.Name == tableName + "s");
    
    	using (var db = new ClearGUIEntities())
    	{
    		var dbset = prop?.GetValue(db);
    
    		return new List<T>(dbset as IEnumerable<T>);
    	}
    }
