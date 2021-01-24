	// Allocate results using collection initializer syntax
	// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#collection-initializers
	var results = new List<Dictionary<string, Dictionary<string, JsonParametersData>>>()
	{
		new Dictionary<string, Dictionary<string, JsonParametersData>>()
		{
			{
				"testmodule1",
				new Dictionary<string, JsonParametersData>()
				{
					{
						"name",
						new JsonParametersData
						{
							required = true,
							options = new List<string>() { "option1", "option1" },
						}
					},
					{
						"admin",
						new JsonParametersData
						{
							required = true,
							options = new List<string>() { "option1", "option1" },
						}
					},
					{
						"path",
						new JsonParametersData
						{
							required = true,
							options = new List<string>() { "option1", "option1" },
						}
					}
				}
			},
		}
	};
	
	// Now add another result, allocating the dictionary with collection initializer syntax also
	// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer
	results.Add(new Dictionary<string, Dictionary<string, JsonParametersData>>()
		{
			{
				"testmodule2",
				new Dictionary<string, JsonParametersData>()
				{
					{
						"name",
						new JsonParametersData
						{
							required = true,
							options = new List<string>() { "option1", "option1" },
						}
					},
					{
						"server",
						new JsonParametersData
						{
							required = true,
							options = new List<string>() { "option1", "option1" },
						}
					},
					{
						"port",
						new JsonParametersData
						{
							required = true,
							options = new List<string>() { "option1", "option1" },
						}
					}
				}
			}
		});
	
	var json = JsonConvert.SerializeObject(results, Formatting.Indented);
