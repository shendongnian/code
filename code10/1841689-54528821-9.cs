    public void GetServerTime(double craftTime, Action<double, double> callback)
    {
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {          
            DateTime now = result.Time.AddHours(1); // GMT+1
    
            // Execute whatever was set as callback passing it the serverTime
            callback?.Invoke(craftTime, Utilities.ConvertToUnixTimestamp(now));         
        }, null);
    }
