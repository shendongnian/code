    public static void Remove<T>(this Queue<T> queue, T itemToRemove) where T : class
    {
    	var list = queue.ToList(); //Needs to be copy, so we can clear the queue
    	queue.Clear();
    	foreach (var item in list)
    	{
    		if (item == itemToRemove)
    			continue;
    
    		queue.Enqueue(item);
    	}
    }
    
    public static void RemoveAt<T>(this Queue<T> queue, int itemIndex) where T : class
    {
    	var list = queue.ToList(); //Needs to be copy, so we can clear the queue
    	queue.Clear();
    
    	for (int i = 0; i < list.Count; i++)
    	{
    		if (i == itemIndex)
    			continue;
    
    		queue.Enqueue(list[i]);
    	}
    }
