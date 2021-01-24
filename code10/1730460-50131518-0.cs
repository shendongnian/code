      class Program
      {
        public static EventWaitHandle handle = new EventWaitHandle(false, EventResetMode.AutoReset);
        public static EventWaitHandle autohandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        static readonly int ThreadNum = 3;
    
        static void Main(string[] args)
        {
          object lk = new object();
          new Thread(() => {
    
            while (true)
            {
    
              var key = Console.ReadKey();
              if (key.Key == ConsoleKey.A)
              {
                handle.Set();
              }
              else
              {
                handle.Reset();
              }
              Thread.Sleep(3000);
    
    
            }
          }).Start();
    
          for (int i = 0; i < ThreadNum; i++)
          {
            int temp = i;
            new Thread(() => ThreadMethod(temp)).Start();
          }
    
          Console.WriteLine("Hello World!");
        }
        private static void ThreadMethod(object obj)
        {
          int val = (int)obj;
          Console.WriteLine($"Thread:{val} created");
          while (true)
          {
    
            handle.WaitOne();
    
            Console.WriteLine($"From thread:{val}");
            Thread.Sleep(1000);
          }
        }
      }
