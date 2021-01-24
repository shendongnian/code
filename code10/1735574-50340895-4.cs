    public void MapJTokenToStaticClass(JToken source)
    {
    	var destinationProperties = typeof(A)
            .GetProperties(BindingFlags.Public | BindingFlags.Static);
    	
    	foreach (JProperty prop in source)
    	{
    		var destinationProp = destinationProperties
                .SingleOrDefault(p => p.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase));
    		var value = ((JValue)prop.Value).Value;
            //The ChangeType is required because JSON.Net will deserialise
            //numbers as long by default
    		destinationProp.SetValue(null, Convert.ChangeType(value, destinationProp.PropertyType));
    	}
    }
