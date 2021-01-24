    // not ideal, but it fits your constraints
    var query = ctx.FooBars.AsQueryable()
        		.Where(f => f.Id > 240)
        		.Select(select)
                .ToListAsync().Result
                .Select(r => new FooBar().Fill(r));
    
    public static T Fill<T>(this T item, object element)
    {
    	var type = typeof(T);
    	var data = element.GetType().GetProperties()
    		.Select(e => new
    		{
    			e.Name,
    			Value = e.GetValue(element)
    		});
    	foreach (var property in data)
    	{
    		type.GetProperty(property.Name).SetValue(item, property.Value);
    	}
    	return item;
    }
