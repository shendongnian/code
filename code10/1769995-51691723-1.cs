	async Task Main()
	{
		string[] a0_source = new[] { "Hello", "World" };
		string[] a1_source = new[] { "Hi", "There" };
	
		IObservable<string> query =
			from a in a0_source.Concat(a1_source).ToObservable()
			from b in Observable.FromAsync(() => ExecuteB(a))
			from c in Observable.FromAsync(() => ExecuteC(b))
			select c;
	
		var output = String.Join(", ", await query.ToArray());
		
		Console.WriteLine(output);
	}
	
	private static async Task<string> ExecuteC(string value)
	{
		return await Task.Run(() => value + "!C");
	}
	
	private static async Task<string> ExecuteB(string value)
	{
		return await Task.Run(() => value + "!B");
	}
