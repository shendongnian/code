    public void StartCraft(double craftTime)
    {
        playFab.GetServerTime(
            result =>
            {
                double endTime = result + craftTime;   
                StartCrafting(craftTime);
            }
        );
    }
