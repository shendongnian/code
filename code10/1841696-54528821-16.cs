    public void StartCraft(double craftTime)
    {
        playFab.GetServerTime(
            serverTime =>
            {
                double endTime = serverTime + craftTime;   
                StartCrafting(craftTime);
            }
        );
    }
