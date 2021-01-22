    [Runtime.CompilerServices.Extension()]
    public IEnumerable<IEnumerable<T>> Paginate<T>(IEnumerable<T> source, int pageSize)
    {
    	List<IEnumerable<T>> pages = new List<IEnumerable<T>>();
    	int skipCount = 0;
    
    	while (skipCount * pageSize < source.Count) {
    		pages.Add(source.Skip(skipCount * pageSize).Take(pageSize));
    		skipCount += 1;
    	}
    
    	return pages;
    }
