	public void testMethod()
	{
		foreach (var type in listType)
		{
			Console.WriteLine(ListClass<type>.getValues());
		}
	}
