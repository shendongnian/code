	static IEnumerable<T> GetInstances<T>() 
	{
		var baseType = typeof(T);
		var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany( a => a.GetTypes() )
            .Where( t => baseType.IsAssignableFrom(t) );
		
		foreach (var t in types)
		{
			yield return (T)Activator.CreateInstance(t);
		}
	}
