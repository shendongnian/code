	protected void Remove<T>(T someData) 
	{
		foreach(var property in typeof(T).GetProperties()) 
		{
			if (property.GetCustomAttribute<HideAttribute>==null) 
				continue;
			Type t = property.PropertyType;
			if (property.CanWrite) 
			{
				property.SetValue(someData,null) 
			} 
			else if (property.CanRead && typeof(ICollection).IsAssignableFrom(t)) 
			{
                var collection = (ICollection)property.GetValue(data);
				collection.Clear();
			}
		}
	}
