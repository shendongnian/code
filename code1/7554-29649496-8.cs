    var dictionaries2 = dictionaries.Where(d =>
		{
			var type = d.GetType();
			return type.IsGenericType && typeof(IDictionary<,>).IsAssignableFrom(type.GetGenericTypeDefinition());
		}); // count == 0!!
