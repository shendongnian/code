    private async Task CallingMethod(string cust, string userId)
    {
      await MehodA(string cust, string userId);
    }
    
    private async Task MehodA(string cust, string userId)
    {
        List<Task> tasks = new List<Task>();
        using (var throttler = new SemaphoreSlim(10))
        {
          foreach (var cust in e.customers)
          {
            tasks.Add(tasks.Add(Task.Run(async () =>
    	    {
              try
              {
    	        await exMan.perfomAction(cust, userId);
              }
    	      finally
    	      {
    	        throttler.Release();
    	      }
            }));
          }
        }
        await Task.WhenAll(tasks);
    }
