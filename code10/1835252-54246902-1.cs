    private Task ActivateAsyncTicToc()
    {
       IsTimerStartAsync = !IsTimerStartAsync;    
       return AsyncTicToc();
    }
