    private IEnumerable<dynamic> GetDbSetByTableName(string tableName)
    {
    	System.Reflection.PropertyInfo[] properties = typeof(ClearGUIEntities).GetProperties();
    	var prop = properties.FirstOrDefault(p => p.Name == tableName + "s");
    
    	using (var db = new ClearGUIEntities())
    	{
    		var dbset = prop?.GetValue(db);
    
    		return new List<dynamic>(dbset as IEnumerable<dynamic>);
    	}
    }
    // ...
    // At this point, you can basically access any property of this entity
    // at the cost of type-safety
    string id = dynamicdbset.FirstOrDefault().Id;
    string name = dynamicdbset.FirstOrDefault().Name;
