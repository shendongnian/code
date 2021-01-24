    void Awake()
    {
        UnityThread.initUnityThread();
    }
    
    private void GetStoredHighScores(Action<string> callback)
    {
        string JsonLeaderBoardResult;
        DataBaseModel.Instance.RetriveLeaderBoard(result =>
                {
                    JsonLeaderBoardResult = result; //gets the data
    
                    UnityThread.executeInUpdate(() =>
                    {
                        if (callback != null)
                            callback(JsonLeaderBoardResult);
                    });
                });
    }
