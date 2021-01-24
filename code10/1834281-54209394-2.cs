	public static async Task Foo()
	{
		await Task.Delay(1);
		Console.WriteLine("Foo!");
	}
	public static async Task Bar()
	{
		await Task.Delay(1);
		Console.WriteLine("Bar!");
	}
