    var tasks = new List<Task>();
    foreach (var val in items.Values)
        tasks.Add(Task.Factory.StartNew(val.UpdateMarketData(client, HQOnly.Checked, retainers)));
    
     try
     {
        // Wait for all the tasks to finish.
        Task.WaitAll(tasks.ToArray());
        //make use of WhenAll method if you dont want to block thread, and want to use async/await 
    
        Console.WriteLine("update completed");
      }
      catch (AggregateException e)
      {
         Console.WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
        for (int j = 0; j < e.InnerExceptions.Count; j++)
        {
            Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
        }
      }
