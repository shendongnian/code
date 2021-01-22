    using System;
    using System.Diagnostics;
    
    class Test
    {
        static void Main()
        {
            int i = 0;
            Debug.Assert(i++ < 10);
            Console.WriteLine(i);
        }
    }
