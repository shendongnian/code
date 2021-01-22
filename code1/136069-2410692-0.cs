    public static void Main(string[] args)
    {
        string processName = Process.GetCurrentProcess().ProcessName;
        int processorCount = Environment.ProcessorCount;
    
        // Simulate process usage
        for (int i = 0; i < processorCount * 2; i++)
        {
            var t = new Thread(() =>
                {
                    while (true) { Console.WriteLine("Busy..."); }
                });
    
            t.IsBackground = true;
            t.Start();
        }
    
        var cpu = new PerformanceCounter("Process", "% Processor Time");
        cpu.InstanceName = processName;
        cpu.NextValue();
    
        var ram = new PerformanceCounter("Process", "Working Set");
        ram.InstanceName = processName;
    
        float memUsage = (ram.NextValue() / 1024) / 1024;
        Console.WriteLine("Memory Usage: {0}MB", memUsage);
    
        float cpuUsage = cpu.NextValue() / (float)processorCount;
        Console.WriteLine("CPU Usage: {0}%", cpuUsage);
    }
