    public void MapToStaticClass(B source)
    {
    	var sourceProperties = source.GetType().GetProperties();
        //Key thing here is to specify we want the static properties only
    	var destinationProperties = typeof(A)
            .GetProperties(BindingFlags.Public | BindingFlags.Static);
    	
    	foreach (var prop in sourceProperties)
    	{
            //Find matching property by name
    		var destinationProp = destinationProperties
                .Single(p => p.Name == prop.Name);
            //Set the static property value
    		destinationProp.SetValue(null, prop.GetValue(source));
    	}
    }
