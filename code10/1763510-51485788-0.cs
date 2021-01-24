	public static async Task Foo()
	{
		Console.WriteLine("Simulating async with a tiny delay");
		await Task.Delay(1);
		
		Console.WriteLine("Throwing");
		throw new Exception("Foo");
	}	
	
	public static async Task MainAsync()
	{
		List<Task> tasks = new List<Task>();
		Console.WriteLine("Adding task");
        tasks.Add(Foo());
		
		Console.WriteLine("Waiting one second");
		await Task.Delay(1000);
		Console.WriteLine("Awaiting task");
		await Task.WhenAll(tasks);
	}
	
	public static void Main()
	{
		MainAsync().GetAwaiter().GetResult();
	}
