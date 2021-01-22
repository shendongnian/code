    PerformanceCounter cpuCounter;
    PerformanceCounter ramCounter;
    
    cpuCounter = new PerformanceCounter();
    
    cpuCounter.CategoryName = "Processor";
    cpuCounter.CounterName = "% Processor Time";
    cpuCounter.InstanceName = "_Total";
    
    ramCounter = new PerformanceCounter("Memory", "Available MBytes");
    
    
    public string getCurrentCpuUsage(){
                cpuCounter.NextValue()+"%";
    }
    
    public string getAvailableRAM(){
                ramCounter.NextValue()+"MB";
    }
