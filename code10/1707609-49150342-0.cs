    var propertyValuesByName = client.GetType().GetProperties()
        .Where(pi => pi.PropertyType == typeof(string))	// use type check as Steve Harris suggested	
    	.Select(pi => new { Val = (string) pi.GetValue(client), Name = pi.Name })
        .Where(pi => !string.IsNullOrEmpty(pi.Val))
    	.ToDictionary(pi => pi.Name, pi => pi.Val);
