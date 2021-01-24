	List<int> list = new List<int>();
	IEnumerable<int> values = list.DefaultIfEmpty(0);
	list.Add(5);
	list.Add(10);
	list.Add(15);
	Console.WriteLine(values.Average()); // 10
