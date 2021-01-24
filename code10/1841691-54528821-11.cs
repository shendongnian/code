    public void GetServerTime(Action<double> callback)
    {
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {          
            DateTime now = result.Time.AddHours(1); // GMT+1
    
            // Execute whatever was set as callback passing it the serverTime
            callback?.Invoke(Utilities.ConvertToUnixTimestamp(now));         
        }, null);
    }
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
