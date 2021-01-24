		var items = new List<Item>
		{
			new Item 
			{
				Values = new List<decimal> { 2, 3, 5 },
				GroupingKey = "P23",
				Cycle = new List<int> { 1, 2, 3, 4 }
			},
			new Item 
			{
				Values = new List<decimal> { 10, 20, 30 },
				GroupingKey = "P23",
				Cycle = new List<int> { 1, 2, 3, 4 }
			},
			new Item 
			{
				Values = new List<decimal> { 10, 20, 30 },
				GroupingKey = "P24",
				Cycle = new List<int> { 1, 2, 3, 4 }
			} 
		};
		
		var merged = items
			.GroupBy(x => x.GroupingKey)
			.Select(grp => new Item
			{
				Values = grp
					.Select(x => x.Values)
					.Aggregate((a, b) => 
						a.Zip(b, (x, y) => x + y).ToList()),
				GroupingKey = grp.Key,
				Cycle = grp.First().Cycle   // can add check that others are identical
			})
			.ToList();
		
		Console.WriteLine(string.Join("\r\n", merged.Select(x => string.Join(",", x.Values))));
