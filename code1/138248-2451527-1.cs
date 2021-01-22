    using (PerformanceCounter pc = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
    {
        while (true)
        {
            Console.WriteLine(pc.NextValue());
            Thread.Sleep(100);
        }
    }
