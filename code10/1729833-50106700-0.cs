	var dictionary = new Dictionary<char, int>();
	foreach(char c in input)
	{
        //faster than Any()
		if(!dictionary.ContainsKey(c))
		{
			dictionary.Add(c, 1);
		}
	}
    
