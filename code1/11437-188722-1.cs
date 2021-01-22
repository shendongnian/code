    using System;
    class Test
    {
        Test()
        {
            throw new Exception();
        }
    
        ~Test()
        {
            Console.WriteLine("Finalized");
        }
        static void Main()
        {
            try
            {
                new Test();
            }
            catch {}
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
