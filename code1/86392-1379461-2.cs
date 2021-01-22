    using System;
    using System.Threading;
    
    class Test
    {
        static void Main()
        {
            for (int i=0; i <= 100; i++)
            {
                Console.Write("\r{0}%", i);
                Thread.Sleep(50);
            }
        }
    }
