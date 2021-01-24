    		List<string> addresses = new List<string>();
    		for (int i = 0; i < 20; i++)
    		{
    			addresses.Add(string.Empty);
    		}
    
    		Parallel.For(0, 
    					 addresses.Count, 
    					 new ParallelOptions{MaxDegreeOfParallelism = 5}, 
    					 i =>
    					{
    						Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss"));
    						Task.Delay(1000).Wait(); // simulating a long running event
    					}
    		);    	
