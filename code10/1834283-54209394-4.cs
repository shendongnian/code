	public static async Task<bool> Foo()
	{
		await Task.Delay(1);
		Console.WriteLine("Foo!");
        return true;
	}
	public static async Task<bool> Bar()
	{
		await Task.Delay(1);
		Console.WriteLine("Bar!");
        return true;
	}
	var actions = new List<Func<Task<bool>>>
	{
		Foo, Bar
	};
	var tasks = actions.Select( x => x() );
	await Task.WhenAll(tasks);
