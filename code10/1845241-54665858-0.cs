    List<int> name = new List<int>();
    for (int i = 0; i < 10; ++i)
    {
		bool check;
		string input = Console.ReadLine();
		check = int.TryParse(input, out int val);
		if (check)
		{
			name.Add(val);
		}
		else
		{
			Environment.Exit(0);
		}
    }
