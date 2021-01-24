	public static async Task<string> ExecuteWithinScope<TReturn>(Func<ICatalogCollection, Task<string>> func)
	{
		Console.WriteLine("4");
		if (func == null) throw new ArgumentNullException("func");
		Console.WriteLine("5");
		using (var catalogCollection = Resolver())
		{
			Console.WriteLine("7");
			return await func(catalogCollection); // waiting task for completition
		}
	}
