    public static void MyParallelMethod()
    {
        var dop = GetDegreeOfParallelism();
        
        //use parallel methods and pass them the degree of parallelism
        
        var result = linqSource
            .AsParallel()
            .WithDegreeOfParallelism(dop)
            .Where(...)
            .Select(...)
            .
            ...;
    }
    
    private static int GetDegreeOfParallelism()
    {
        var corecount = Environment.ProcessorCount;
        var myCompInfo = new ComputerInfo();
        var availableRam = myCompInfo.TotalPhysicalMemory / 1024 / 1024;
    
        //Devise your logic to calculate dop...
        //Return 1 when no parallelism is possible.
        return dop;
    }
