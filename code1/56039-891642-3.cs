    using System;
    using System.Threading;
    namespace ManyThreadsClient
    {
      internal class Program
      {
        private static void Main(string[] args)
        {
          // first argument is the number of threads
          for (var i = 0; i < Int32.Parse(args[0]); i++)
            new Thread(RunClient).Start();
        }
        private static void RunClient()
        {
          new Client();
        }
      }
    }
