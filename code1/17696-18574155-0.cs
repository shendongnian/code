    var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
    int usage = (int) cpuCounter.NextValue();
    while (usage == 0 || usage > 80)
    {
         Thread.Sleep(250);
         usage = (int)cpuCounter.NextValue();
    }
