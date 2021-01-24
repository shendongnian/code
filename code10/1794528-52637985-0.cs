	var arrays = new[]
	{
		new[] {"A", "B", "C", "D", "E", "F"},
		new[] {"A", "B", "B", "C", "D", "D", "D", "E", "F"},
		new[] {"A", "B", "B", "C", "D", "D", "E", "F"},
		new[] {"A", "B", "B", "B", "C", "D", "D", "E", "F"},
		new[] {"A", "B", "B", "C", "D", "E", "E", "F"},
	};
	
	var result =
		arrays
			.SelectMany(xs => xs.GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() }))
			.GroupBy(x => x.Key, x => x.Count)
			.Select(x => new { x.Key, Count = x.Max() })
			.SelectMany(x => Enumerable.Repeat(x.Key, x.Count))
			.ToArray();
