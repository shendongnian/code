    // following declaration of delegate ,,,
    public delegate long GetEnergyUsageDelegate(DateTime lastRunTime, 
                                                DateTime procDateTime);
    // following inside of some client method 
    GetEnergyUsageDelegate nrgDel = GetEnergyReadings;                     
    IAsyncResult aR = nrgDel.BeginInvoke(lastRunTime, procDT, null, qryProgress);
    while (!aR.IsCompleted) Thread.Sleep(500);
    long usageCnt = nrgDel.EndInvoke(aR);
