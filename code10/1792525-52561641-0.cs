	public static Configuration CreateFromDictionary(Dictionary<string, string> dict)
	{
		var mappings = new Dictionary<string, Action<Configuration, string>>
		{
			[nameof(Name)] = (x, value) => x.Name = value,
			[nameof(Url)] = (x, value) => x.Url = value,
			[nameof(Password)] = (x, value) => x.Password = value,
		};
		
		var missingKeys = mappings.Keys
			.Except(dict.Keys)
			.ToArray();
		if (missingKeys.Any())
			throw new KeyNotFoundException("The given keys are missing: " + string.Join(", ", missingKeys));
		
		return mappings.Aggregate(new Configuration(), (config, mapping) =>
		{
			mapping.Value(config, dict[mapping.Key]);
			return config;
		});
	}
