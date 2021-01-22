    public static IEnumerable<int> QSLinq(IEnumerable<int> items)
    {
    	if (items.Count() <= 1)
    		return items;
    
    	int pivot = items.First();
    
    	return QSLinq(items.Where(i => i < pivot))
    		.Concat(items.Where(i => i == pivot))
    		.Concat(QSLinq(items.Where(i => i > pivot)));
    }
