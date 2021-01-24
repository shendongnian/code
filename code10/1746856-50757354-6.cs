	public static async Task ExecuteWithinScope<TReturn>(Func<ICatalogCollection, Task> func)
	{
		Console.WriteLine("4");
		if (func == null) throw new ArgumentNullException("func");
		Console.WriteLine("5");
		using (var catalogCollection = Resolver())
		{
			Console.WriteLine("7");
			await func(catalogCollection); // waiting task for completition
		}
	}
