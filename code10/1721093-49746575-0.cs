    void checkEntitlement()
    {
        Entitlements.IsUserEntitledToApplication().OnComplete(
        (Message msg) =>
        {
            if (msg.IsError)
            {
                // User is NOT entitled.
                Debug.Log("Error: User not entitled");
            } else 
            {
                // User IS entitled
                Debug.Log("Success: User entitled");
                checkEntry();
            }
        }
    );
    }
    
    void checkEntry()
    {
        Leaderboards.GetEntries("POC-Score", 10, LeaderboardFilterType.None, LeaderboardStartAt.Top).OnComplete(GetEntriesCallback);
    }
    void GetEntriesCallback(Message<LeaderboardEntryList> msg)
    {
        Debug.Log("-----");
        Debug.Log(msg.Data);
        Debug.Log("-----");
    }
