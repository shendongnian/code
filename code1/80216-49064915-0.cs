    public object GetUsage()
    {
        // Getting information about current process
        var process = Process.GetCurrentProcess();
        // Preparing variable for application instance name
        var name = string.Empty;
        foreach (var instance in new PerformanceCounterCategory("Process").GetInstanceNames())
        {
            if (instance.StartsWith(process.ProcessName))
            {
                using (var processId = new PerformanceCounter("Process", "ID Process", instance, true))
                {
                    if (process.Id == (int)processId.RawValue)
                    {
                        name = instance;
                        break;
                    }
                }
            }
        }
        var cpu = new PerformanceCounter("Process", "% Processor Time", name, true);
        var ram = new PerformanceCounter("Process", "Private Bytes", name, true);
        // Getting first initial values
        cpu.NextValue();
        ram.NextValue();
        // Creating delay to get correct values of CPU usage during next query
        Thread.Sleep(500);
        dynamic result = new ExpandoObject();
            
        // If system has multiple cores, that should be taken into account
        result.CPU = Math.Round(cpu.NextValue() / Environment.ProcessorCount, 2);
        // Returns number of MB consumed by application
        result.RAM = Math.Round(ram.NextValue() / 1024 / 1024, 2);
        return result;
    }
