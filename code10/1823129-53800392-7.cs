    public IEnumerable<Stat<T>> CountOccurance<T>(IEnumerable<T> source)
    {
    	var lastItem = source.First();
    	var count = 1;
    	var index= 0;
    	foreach(var item in source.Skip(1))
    	{
    		if(item.Equals(lastItem))
    		{
    			count++;
    		}
    		else
    		{
    			yield return new Stat<T>
    			{
    				Index = index,
    				StringValue = lastItem,
    				Count = count
    			};
    			count=1;
    			lastItem = item;
                index++;
    		}
    		
    	}
    	
    	yield return new Stat<T>
    	{
    		Index = index,
    		StringValue = lastItem,
    		Count = count
    	}; 
    }
