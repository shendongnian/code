    using System;
    using System.Threading;
    
    public class Test
    {
        static void Main()
        {
            Action x = () => 
                Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            
            x(); // Synchronous; prints False
            x.BeginInvoke(null, null); // On the thread-pool thread; prints True
            Thread.Sleep(500); // Let the previous call finish
        }
    }
