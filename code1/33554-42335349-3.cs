    public static void RemoveAt<T>(this Queue<T> queue, int itemIndex)
    {
        var cycleAmount = queue.Count;
    	
    	for (int i = 0; i < cycleAmount; i++)
    	{
            T item = queue.Dequeue();
    		if (i == itemIndex)
    			continue;
    
    		queue.Enqueue(item);
    	}
    }
