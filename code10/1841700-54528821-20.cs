    public void StartCraft(double craftTime)
    {
        playFab.GetServerTime(
            serverTime =>
            {
                OnServerTimeReceived(craftTime, serverTime);
            }
        );
    }
    private void OnServerTimeReceived(double craftTime, double serverTime)
    {
        double endTime = serverTime + craftTime;   
        StartCrafting(craftTime);
    }
