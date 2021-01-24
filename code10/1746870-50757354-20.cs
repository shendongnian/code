	public static TReturn ExecuteWithinScope<TReturn>(Func<ICatalogCollection, TReturn> func)
	{
		Console.WriteLine("4");
		if (func == null) throw new ArgumentNullException("func");
		Console.WriteLine("5");
		//using (var catalogCollection = Resolver()) // not in using!
		{
			var catalogCollection = Resolver();
			Console.WriteLine("7");
			return func(catalogCollection);
		}
	}
