	var rootName = "Customer";
	
	var query = customerDBList
		// Convert to JObject
		.Select(c => JObject.FromObject(c))
		// Add additional level of object nesting { "Customer": { ... } } 
		.Select(o => new JObject( new JProperty(rootName, o)))
		// Remove all but selected properties.
		.Select(o => o.RemoveAllExcept(selectedDropDownValues));
	
	var json = JsonConvert.SerializeObject(query, Formatting.Indented);
