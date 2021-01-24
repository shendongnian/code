	[HttpGet]
	public IActionResult Get([FromServices] IConfiguration config)
	{
		var result = new ExpandoObject();
		
		// retrieve all keys for you settings
		var configs = config.AsEnumerable().Where(_ => _.Key.StartsWith("mySettings"));
		foreach(var kvp in configs) 
		{
			var parent = result as IDictionary<string, object>;
			var path = kvp.Key.Split(':');
			
			// create or retrive the hierarchy (keep last path item for later)
			var i = 0;
			for (i = 0; i < path.Length - 1; i++)
			{
				if (!parent.ContainsKey(path[i]))
				{
					parent.Add(path[i], new ExpandoObject());
				}
				
				parent = parent[path[i]] as IDictionary<string, object>;
			}
			if (kvp.Value == null)
				continue;
			
			// add the value to the parent
			// note: in case of an array, key will be an integer and will be dealt later
			var key = path[i];
			parent.Add(key, kvp.Value);
		}
		
		// at this stage, all arrays are seen as dictionaries with integer keys
		ReplaceWithArray(null, null, result);
		
		return Ok(result);
	}
	private void ReplaceWithArray(ExpandoObject parent, string key, ExpandoObject input) 
	{
		if (input == null)
			return;
		
		var dict = input as IDictionary<string, object>;
		var keys = dict.Keys.ToArray();
		if (keys.All(k => int.TryParse(k, out var dummy))) {
			var array = new object[keys.Length];
			foreach(var kvp in dict) {
				array[int.Parse(kvp.Key)] = kvp.Value;
			}
			
			var parentDict = parent as IDictionary<string, object>;
			parentDict.Remove(key);
			parentDict.Add(key, array);
		}
		else
		{
			foreach (var childKey in dict.Keys.ToList())
			{
				ReplaceWithArray(input, childKey, dict[childKey] as ExpandoObject);
			}
		}
	}
