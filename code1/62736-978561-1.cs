    IEnumerable<Item> original = new[] { 1, 2, 3, 4, 5 }.Select(x => new Item
    	{
    		Key = x,
    		Value = x
    	});
    IEnumerable<Item> changed = new[] { 2, 3, 5 }.Select(x => new Item
    	{
    		Key = x,
    		Value = x * x
    	});
    IEnumerable<Item> result = original.Except(changed, x => x.Key).Concat(changed);
    result.ForEach(Console.WriteLine);
