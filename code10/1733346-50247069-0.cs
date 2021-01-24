	char[] splitters = new[] { '@', '<', '>', '=', '$', '%', '&' };
	
	string text = "first name => saran    address @> my address";
	
	string[] results =
		text
			.Aggregate(new List<List<char>>() { new List<char>() }, (a, c) =>
			{
				var l = a.Last();
				if (splitters.Contains(c) && !l.All(x => splitters.Contains(x)))
				{
					l = new List<char>() { c };
					a.Add(l);
				}
				else
				{
					l.Add(c);
				}
				return a;
			})
			.Select(x => new string(x.ToArray()))
			.ToArray();
