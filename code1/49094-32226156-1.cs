	void Main()
	{
		var list = new List<int>();
		for (int i = 0; i < 10; i++)
			list.Add(i);
		//foreach (var entry in list)
		for (int i = 0; i < list.Count; i++)
		{
			var entry = list[i];
			if (entry % 2 == 0)
				list.Add(entry + 1);
			Console.Write(entry + ", ");
		}
		Console.Write(list);
	}
