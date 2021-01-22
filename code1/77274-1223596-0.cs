    class Test
    {
        static void ExecuteLongRunningTask()
        {
            Console.WriteLine("Sleeping...");
            Thread.Sleep(1000);
            Console.WriteLine("... done");
        }
        
        static void Main()
        {
            ExecuteLongRunningTask();
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
