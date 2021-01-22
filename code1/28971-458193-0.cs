    using System.Threading;
    using System;
    static class BackgroundTaskDemo
    {
        // make this volatile to fix it
        private static bool stopping = false;
    
        static void Main()
        {
            new Thread(DoWork).Start();
            Thread.Sleep(5000);
            stopping = true;
    
    
            Console.WriteLine("Main exit");
            Console.ReadLine();
        }
    
        static void DoWork()
        {
            int i = 0;
            while (!stopping)
            {
                i++;
            }
    
            Console.WriteLine("DoWork exit " + i);
        }
    }
