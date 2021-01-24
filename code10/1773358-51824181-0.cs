    int maxConcurrency = 10;
    var messages = new List<string>() { "1", "2", "3" };
    using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(maxConcurrency))
    {
        //List<Task> tasks = new List<Task>();
        foreach (var msg in messages)
        {
            concurrencySemaphore.Wait();
            var t = Task.Factory.StartNew(() =>
            {
                try
                {
                    Thread.Sleep(5000);
                }
                finally
                {
                    concurrencySemaphore.Release();
                }
            });
            //tasks.Add(t);
        }
        //Task.WaitAll(tasks.ToArray());
    }
