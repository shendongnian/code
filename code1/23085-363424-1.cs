    // following declaration of delegate ,,,
    public delegate long GetEnergyUsageDelegate(DateTime lastRunTime, 
                                                DateTime procDateTime);
    // following inside of some client method 
    GetEnergyUsageDelegate nrgDel = GetEnergyUsage;                     
    IAsyncResult aR = nrgDel.BeginInvoke(lastRunTime, procDT, null, null);
    while (!aR.IsCompleted) Thread.Sleep(500);
    int usageCnt = nrgDel.EndInvoke(aR);
