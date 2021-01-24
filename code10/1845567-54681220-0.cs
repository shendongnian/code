	List<string> names = new List<string>()
	{
	    "alice",
	    "bob",
	    "curt"
	};
	
	string[][] modifiedNames =
		names
			.Select(name =>
				Enumerable
					.Range(0, name.Length)
					.Select(x => name.Substring(0, x) + name.Substring(x + 1))
					.Concat(new [] { name })
					.ToArray())
			.ToArray();
