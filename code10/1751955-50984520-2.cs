	public void testMethod()
	{
		foreach (var type in listType)
		{
			Console.WriteLine(
				(bool)typeof(ListClass<>)
					.MakeGenericType(type)
					.GetMethod("getValues")
					.Invoke(null, new object[] { }));
		}
	}
