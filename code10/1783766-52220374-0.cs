    var dict = new Dictionary<(int, int), string>();
	for (int i = 0; i < 2; i++)
	{
		for (int j = 0; j < 5; j++)
			dict.Add((i, j), "");
	}
	dict[(1, 1)] = "Hello";
