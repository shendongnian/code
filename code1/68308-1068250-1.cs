    // Do never ever use this
    private void DoNothing(){ }
    private void KillCPU()
    {
        DateTime target = DateTime.Now.AddSeconds(10);
        while(DateTime.Now < target) DoNothing();
        DoStuffAfterWaiting10Seconds();
    }
