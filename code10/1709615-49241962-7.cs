    Type type = typeof(FooBar);
	var properties = type
      .GetProperties()
	  .Where(p => p.PropertyType.IsGenericType)
      .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
      .Where(p => typeof(ISomeThing).IsAssignableFrom(
        p.PropertyType.GenericTypeArguments.Single()))
    Console.WriteLine(properties.Count()); // 2
