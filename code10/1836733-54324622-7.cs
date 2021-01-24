    static void Main(string[] args)
    {
      ThreadPool.SetMinThreads(MaxThreads, 1);
      Console.WriteLine(ThreadPool.SetMaxThreads(MaxThreads, 1));
      Console.WriteLine("Start Requests");
      var requests = Enumerable.Range(0, 200)
        .Select(async (x) => await Task.Run(() => SomeMethod2(new StateInfo { Order = x, WaitFor = 0 })))
        .ToArray();
      Console.WriteLine("Wait for them.");
      Task.WaitAll(requests.ToArray());
      
      Console.WriteLine("Main thread exits.");
      Console.ReadKey();
    }
