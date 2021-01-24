	List<Type> knownTypes = new List<Type>();
	foreach(Type t in Assembly.GetExecutingAssembly().GetTypes())
	{
		if (typeof(Entity).IsAssignableFrom(t))
			knownTypes.Add(t);
	}
