    public static IEnumerable<IEnumerable<T>> Split<T>(this ICollection<T> self, int chunkSize)
    {
    	var splitList = new List<List<T>>();
    	var chunkCount = (int)Math.Ceiling((double)self.Count / (double)chunkSize);
    
    	for(int c = 0; c < chunkCount; c++)
    	{
    		var skip = c * chunkSize;
    		var take = skip + chunkSize;
    		var chunk = new List<T>(chunkSize);
    
    		for(int e = skip; e < take && e < self.Count; e++)
    		{
    			chunk.Add(self.ElementAt(e));
    		}
    
    		splitList.Add(chunk);
    	}
    
    	return splitList;
    }
