    private async Task ActivateAsyncTicToc()
    {
       IsTimerStartAsync = !IsTimerStartAsync;    
       await AsyncTicToc();
    }
