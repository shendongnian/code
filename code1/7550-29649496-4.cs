    var dictionaryInterfaces = new[]
	{
		typeof(IDictionary<,>),
		typeof(IDictionary),
		typeof(IReadOnlyDictionary<,>),
	};
	var dictionaries2 = dictionaries
		.Where(d => d.GetType().GetInterfaces()
			.Any(t=> dictionaryInterfaces
				.Any(i=> i == t || t.IsGenericType && i == t.GetGenericTypeDefinition()))) // count == 5
