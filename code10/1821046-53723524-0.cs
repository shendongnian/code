    static IEnumerable<int> Sample(int count)
	{
		Console.WriteLine("Sample Invoked");
		for (int i = 0; i < count; i++)
			yield return i;
	}
	static IEnumerable<int> ForEach(IEnumerable<int> items, Action<int> action)
	{
		Console.WriteLine("ForEach Invoked:");
		foreach (int item in items)
		{
			action(item);
			yield return item;
		}
	}
