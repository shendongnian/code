    static void Main(string[] args)
    {
        Mutex flag = new Mutex(false, "UNIQUE_NAME");
        bool acquired = flag.WaitOne(TimeSpan.FromMilliseconds(0));  // 0 or more milliseconds
        if (acquired)
        {
            Console.WriteLine("Ok, this is the only instance allowed to run.");
            // do your work, here simulated with a Sleep call
            Thread.Sleep(TimeSpan.FromSeconds(5));
            flag.ReleaseMutex();
            Console.WriteLine("Done!");
        }
        else
        {
            Console.WriteLine("Another instance is running.");
        }
        Console.WriteLine("Press RETURN to close...");
        Console.ReadLine();
    }
