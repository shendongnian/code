	private static async Task DoAsyncThing()
	{
		Console.WriteLine("waiting");
		await Task.Delay(1000);
		Console.WriteLine("waited");
	}
	private static async Task SaveAll()
	{
		Console.WriteLine("Saving");
		await Task.Delay(1000);
	}
	public static async Task ProcessAll()
	{
		var tasks = new List<Task>();
		for (int i = 0; i < 10; i++)
		{
			tasks.Add(DoAsyncThing());
		}
		await Task.WhenAll(tasks);
		await SaveAll();
		Console.WriteLine("Saved");
	}
	public static void Main()
	{
		ProcessAll().Wait();
		Console.WriteLine("sdf");
	}
