    public void RetrieveFirstLevelOptions(Action callback)
    {
        client.RetrieveFirstLevelOptionsAsync(callback);
    }
    void client_RetrieveFirstLevelOptionsCompleted(object sender, AsyncCompletedEventArgs e)
    {
        var callback = e.UserState as Action;
        if (callback != null)
        {
            callback();
        }
    }
