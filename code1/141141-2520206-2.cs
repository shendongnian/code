    int toProcess = 10;
    using(ManualResetEvent resetEvent = new ManualResetEvent(false))
    {
        var list = new List<int>();
        for(int i=0;i<10;i++) list.Add(i); 
        for(int i=0;i<10;i++)
        {
            ThreadPool.QueueUserWorkItem(
               new WaitCallback(x => {
                  Console.WriteLine(x);  
                  // Safely decrement the counter
                  if (Interlocked.Decrement(ref toProcess)==0)
                     resetEvent.Set();
               }),list[i]);
        } 
        resetEvent.WaitOne();
    }
    // When the code reaches here, the 10 threads will be done
    Console.WriteLine("Done");
