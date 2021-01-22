    private IEmployee CachedClassFactory()
	{
		if(_typeCache == null)
		{
			// This is a one time hit to load the type into the cache
			string typeName = "ClassFactoryTest.Employee";
			string assemblyName = "ClassFactoryTest";
			Assembly assembly = Assembly.Load(assemblyName);
			IEmployee employee = assembly.CreateInstance(typeName) as IEmployee;						
			_typeCache = employee.GetType();
		}
	
		IEmployee instance = Activator.CreateInstance(_typeCache) as IEmployee;
		instance.FirstName = "Raiford";
		instance.LastName = "Brookshire";
		instance.Birthdate = DateTime.Now.AddYears(-35);
		instance.Age = 35;
		return instance;	
	}
