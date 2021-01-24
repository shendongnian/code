    public void StartCraft(double craftTime)
    {
        playFab.GetServerTime(OnServerTimeReceived);
    }
    
    private void OnServerTimeReceived(double time)
    {
        double endTime = result + craftTime;   
        StartCrafting(craftTime);
    }
