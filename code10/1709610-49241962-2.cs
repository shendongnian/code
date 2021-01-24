		var properties = type
			.GetProperties()
			.Where(p => p.PropertyType
		      .GetInterfaces()
			  .Concat(new [] {p.PropertyType})
			  .Where(i => i.IsGenericType)
			  .Where(i => i.GetGenericTypeDefinition() == typeof(ICollection<>))
			  .Where(i => typeof(ISomeThing)
                .IsAssignableFrom(i.GetGenericArguments().Single()))
			  .Any());
