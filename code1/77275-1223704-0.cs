    class Test
    {
        void LongRunningTask()
        {
            Console.WriteLine("Sleeping...");
            Thread.Sleep(10000);
            Console.WriteLine("... done");
        }
    
        static void Main()
        {
            Test t = new Test();
            new Action(() => t.LongRunningTask()).BeginInvoke(null, t);
        }
    }
