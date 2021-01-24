    public void StartCraft(double craftTime)
    {
        playFab.GetServerTime(craftTime, OnServerTimeReceived);
    }
    
    private void OnServerTimeReceived(double craftTime, double serverTime)
    {
        double endTime = serverTime + craftTime;   
        StartCrafting(craftTime);
    }
