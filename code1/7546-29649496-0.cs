    var dictionaryInterfaces = new[]
	{
		typeof(IDictionary<,>),
		typeof(IDictionary),
		typeof(IReadOnlyDictionary<,>),
	};
	var dictionaries = collectionOfAnyTypeObjects
		.Where(d => d.GetType().GetInterfaces()
			.Any(t=> dictionaryInterfaces
				.Any(i=> i == t || t.IsGenericType && i == t.GetGenericTypeDefinition())))
