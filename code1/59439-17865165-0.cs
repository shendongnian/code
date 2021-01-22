    var items = new[] {5, 6, 1, 2, 3, 1, 5, 2};
    items
    	.GroupBy(i => i)
    	.Select(g => new {
    		Item = g.Key,
    		Count = g.Count()
    	})
    	.OrderBy(g => g.Item)
    	.ToList()
        .ForEach(g => {
            Console.WriteLine("{0} occurred {1} times", g.Item, g.Count);
        });
