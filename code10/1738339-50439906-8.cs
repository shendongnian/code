    string input = "1 0 1 0 1\n0 0 0 0 0\n1 0 0 0 1\n0 0 0 0 0\n1 0 1 0 1";
    
	List<bool[]> list = new List<bool[]>();
	
	string[] lines = input.Split(new[] { "\n" }, StringSplitOptions.None);
	foreach (string line in lines) // Could be a different loop that gets lines from the user
	{
		string[] chars = line.Split(' '); // Bear with the crappy variable names
		bool[] flagLine = chars.Select(numString => numString == "1").ToArray();
		list.Add(flagLine);
	}
	
	bool[][] flags = list.ToArray();
