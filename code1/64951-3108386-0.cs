    public static void InitializeArray<T>(T[] array, T value)
    {
    	var cores = Environment.ProcessorCount;
    
    	ArraySegment<T>[] segments = new ArraySegment<T>[cores];
    
    	var step = array.Length / cores;
    	for (int i = 0; i < cores; i++)
    	{
    		segments[i] = new ArraySegment<T>(array, i * step, step);
    	}
    	var remaining = array.Length % cores;
    	if (remaining != 0)
    	{
    		var lastIndex = segments.Length - 1;
    		segments[lastIndex] = new ArraySegment<T>(array, lastIndex * step, array.Length - (lastIndex * step));
    	}
    
    	var initializers = new Task[cores];
    	for (int i = 0; i < cores; i++)
    	{
    		var index = i;
    		var t = new Task(() =>
    		{
    			var s = segments[index];
    			for (int j = 0; j < s.Count; j++)
    			{
    				array[j + s.Offset] = value;
    			}
    		});
    		initializers[i] = t;
    		t.Start();
    	}
    
    	Task.WaitAll(initializers);
    }
