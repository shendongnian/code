	async Task Main()
	{
		string[] a0_source = new[] { "Hello", "World" };
		string[] a1_source = new[] { "Hi", "There" };
	
		Task<string[]> A0 = ExecuteA(a0_source);
		Task<string[]> A1 = ExecuteA(a1_source);
	
		var results = await Task.WhenAll(A0, A1);
	
		var output = String.Join(", ", results.SelectMany(x => x));
		
		Console.WriteLine(output);
	}
	
	private static async Task<string[]> ExecuteA(string[] A)
	{
		var BCs = A.Select(r => ExecuteBC(r));
		return await Task.WhenAll(BCs);
	}
	
	private static async Task<string> ExecuteBC(string value)
	{
		var result = await ExecuteB(value);
		return await ExecuteC(result);
	}
	
	private static async Task<string> ExecuteC(string value)
	{
		return await Task.Run(() => value + "!C");
	}
	
	private static async Task<string> ExecuteB(string value)
	{
		return await Task.Run(() => value + "!B");
	}
