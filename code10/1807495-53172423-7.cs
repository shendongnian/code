    public static class MyExtensions
    {
    	// data - List<T>
    	// dataCount - Calculate once and pass to avoid accessing the property everytime
    	// Size of Partition, which can be function of number of processors
    	public static List<T>[] SplitList<T>(this List<T> data, int dataCount, int partitionSize)
    	{
    		int remainderData;    
    		var fullPartition = Math.DivRem(dataCount, partitionSize, out remainderData);    
    		var listArray = new List<T>[fullPartition];    
    		var beginIndex = 0;
    
    		for (var partitionCounter = 0; partitionCounter < fullPartition; partitionCounter++)
    		{
    			if (partitionCounter == fullPartition - 1)
    				listArray[partitionCounter] = data.GetRange(beginIndex, partitionSize + remainderData);
    			else
    				listArray[partitionCounter] = data.GetRange(beginIndex, partitionSize);    
    			beginIndex += partitionSize;
    		}    
    		return listArray;
    	}
    }
