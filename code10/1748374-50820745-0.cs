    private static IEnumerable<String> GetProcessStatistics(String[] processesTosearch)
    {
        Process[] processList = Process.GetProcesses();
        foreach (string process in processesTosearch)
        {
            foreach (Process p in processList)
            {
                if (p.ProcessName == process)
                {
                    StringBuilder sb = new StringBuilder();
                    PerformanceCounter CPUperformanceCounter = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);
                    PerformanceCounter NETWORKperformanceCounter = new PerformanceCounter("Process", "IO Data Operations/Sec", p.ProcessName);
                    // set a baseline
                    CPUperformanceCounter.NextValue();
                    NETWORKperformanceCounter.NextValue();
                    Thread.Sleep(1000);
                    double cpuData = CPUperformanceCounter.NextValue();
                    double networkData = NETWORKperformanceCounter.NextValue();
                    sb.AppendLine("ID: " + p.Id.ToString());
                    sb.AppendLine("NAME: " + p.ProcessName);
                    sb.AppendLine("CPU USAGE: " + cpuData);
                    sb.AppendLine("RAM USAGE: " + ConvertToReadableSize(p.PrivateMemorySize64));
                    sb.AppendLine("NETWORK USAGE: " + networkData);
                    yield return sb.ToString();
                }
            }
        }
    }
