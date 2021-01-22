    int itemCount = 0;
    for (int i = 0; i < 5000; i++)
    {
        Interlocked.Increment(ref itemCount);
    
        ThreadPool.QueueUserWorkItem(x=>{
            try
            {
                //code logic here.. sleep is just for demo
                Thread.Sleep(100);
            }
            finally
            {
                Interlocked.Decrement(ref itemCount);
            }
        });
    }
    
    while (itemCount > 0)
    {
        Console.WriteLine("Waiting for " + itemCount + " threads...");
        Thread.Sleep(100);
    }
    Console.WriteLine("All Done!");
