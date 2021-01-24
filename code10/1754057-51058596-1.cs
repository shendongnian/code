	public static void Main()
	{
		var list = new[]{"abc","abc","abc"};
		
		foreach (var item in list.Select((x,i)=>x[i]))
			Console.WriteLine(item);
	}
