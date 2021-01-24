	public static void Main()
	{
		var list = new List<String>{"a", "b", "c"};
		var collection = new ObservableCollection<string>(list);
		foreach (var value in collection)
		{
			Console.WriteLine(value);
		}
		Console.WriteLine("Hello World");
	}
