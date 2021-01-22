    using System;
    using System.Threading;
    
    class Test
    {
        static void Main()
        {
            for (int i=0; i < 10; i++)
            {
                int copy = i;
                ThreadStart ts = delegate { Console.WriteLine(copy); };
                new Thread(ts).Start();
            }
        }
    }
