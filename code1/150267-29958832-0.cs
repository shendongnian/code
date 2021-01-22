    public static IEnumerable<string> RemoveDuplicates(IEnumerable<string> items)
    {
    	var duplicateIndexes = 	items.Select((item, index) => new { item, index })
    							.GroupBy(g => g.item)
    							.Where(g => g.Count() > 1)
    							.SelectMany(g => g.Skip(1), (g, item) => item.index);
    	return items.Where((item, index) => !duplicateIndexes.Contains(index));
    }
