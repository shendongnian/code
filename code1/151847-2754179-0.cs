    using System;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        [STAThread]
        static void Main(string[] args)
        {
    
          Thread t1 = new Thread(new ThreadStart(AsyncFunc));
          Thread t2 = new Thread(new ThreadStart(AsyncFunc));
    
          t1.Start();
          t2.Start();
    
          // Wait here for the 2 threads to complete
          t1.Join();
          t2.Join();
    
          Console.WriteLine("Done");
          Console.ReadKey();
        }
    
    
        static void AsyncFunc()
        {
          Thread.Sleep(2000);
        }
    
      }
    }  
