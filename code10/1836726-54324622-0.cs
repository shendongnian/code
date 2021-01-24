    class Program
    {
      private const int MaxThreads = 1;
      static void Main(string[] args)
      {
        ThreadPool.SetMinThreads(MaxThreads, 1);
        Console.WriteLine(ThreadPool.SetMaxThreads(MaxThreads, 1));
        Task.Run(() => SomeMethod(new StateInfo { Order = 0, WaitFor = 3000 }));
        Task.Run(() => SomeMethod(new StateInfo { Order = 1, WaitFor = 3000 }));
        Task.Run(() => SomeMethod(new StateInfo { Order = 2, WaitFor = 3000 }));
        Console.WriteLine("Main thread does some work, then sleeps.");
        Thread.Sleep(5000);
        Console.WriteLine("Main thread exits.");
      }
      static void SomeMethod(Object stateInfo)
      {
        var si = (StateInfo)stateInfo;
        Console.WriteLine($"Hello from the thread pool. {si.Order}");
        Thread.Sleep(si.WaitFor);
      }
      public class StateInfo
      {
        public int Order { get; set; }
        public int WaitFor { get; set; }
      }
    }
