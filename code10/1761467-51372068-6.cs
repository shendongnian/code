    public class Example
    {
      public static readonly Object padLock = new Object();
      public readonly static ConcurrentDictionary<string, object> locks = new ConcurrentDictionary<string, object>(); 
      public static List<string> processes = new List<string>(); 
      [ThreadStatic]
      private static bool flag = false;
     public static void Main()
     {
      //Add random list of processes (just testing with one for now)
      for (var i = 0; i < 10; i++)
      {
         processes.Add(i.ToString());
      }
      while (true)
      {
         foreach (var process in processes)
         {
            var currentProc = process; 
            if (!locks.ContainsKey(currentProc))
            {
               var lockObject = locks.GetOrAdd(currentProc, new object());
               Task.Factory.StartNew(() =>
                {
                   lock (lockObject)
                   {
                      if (flag) throw new Exception();
                      flag = true;
                      Console.WriteLine("Currently Executing " + currentProc);
                      Thread.Sleep(0); // You can siimulate work here
                      Console.WriteLine("Ended Executing " + currentProc);
                      flag = false;
                      ((IDictionary)locks).Remove(currentProc);
                   }
                });
            }
         }
       }
      }
    }
