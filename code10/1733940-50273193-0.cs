    public async Task StartOperations()
    {
        Task.WaitAll(new Task[] 
        {
            StartAccessTokenTimer(),
            StartItemsTimer()
        });
    } 
