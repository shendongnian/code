    private static SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);
    
    internal async Task<byte[][]> ExchangeCore(byte[][] apdus)
    {
    	if (apdus == null || apdus.Length == 0)
    		return null;
    		
    	await Semaphore.WaitAsync();
    	
    	try
    	{
    		List<byte[]> resultList = new List<byte[]>();
    		foreach (var apdu in apdus)
    		{
    			await WriteAsync(apdu);
    			var result = await ReadAsync();
    			resultList.Add(result);
    		}
    		return resultList.ToArray();
    	}
    	finally
    	{
    		Semaphore.Release();
    	}
    }
