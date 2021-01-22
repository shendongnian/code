	Type[] types = Assembly.GetExecutingAssembly().GetTypes();
	foreach(Type tp in types)
	{
		if (typeof(IExample).IsAssignableFrom(tp))
		{
			if (tp.IsInterface == false)
			{
				IExample t = Activator.CreateInstance(tp) as IExample;
				Console.WriteLine(t.Foo());
			}
		}
	}
