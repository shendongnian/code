	List<int> main = Enumerable.Range(0,11).ToList();
	
	List<int> a = new List<int>{ 1, 5, 3, 0, 7};
	IEnumerable<int> b = main.Where(i => i % 2 == 0);
	IEnumerable<int> c = main.Where(i => i % 2 == 1);
	
	foreach (var i in b)
	{
		Console.Write(i + ","); // 0, 2, 4, 6, 8, 10
	}
	Console.WriteLine();
	
	foreach (var i in c)
	{
		Console.Write(i + ","); // 1, 3, 5, 7, 9
	}
	Console.WriteLine();
	
	
	foreach (var i in a)
	{
		main.Remove(i);
	}
	
	foreach (var i in b)
	{
		Console.Write(i + ","); // 2, 4, 6, 8, 10
	}
	Console.WriteLine();
	
	foreach (var i in c)
	{
		Console.Write(i + ","); // 9
	}
	Console.WriteLine();
