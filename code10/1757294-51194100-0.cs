    static void Main(string[] args)
    {
        var cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        Thread.Sleep(1000);
        var firstCall = cpuUsage.NextValue();
        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(1000);
            Console.WriteLine(cpuUsage.NextValue() + "%");
        }
        Console.Read();
    }
