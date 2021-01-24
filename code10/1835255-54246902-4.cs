    private async void ActivateAsyncTicToc()
    {
       try
       {
          IsTimerStartAsync = !IsTimerStartAsync;    
          await AsyncTicToc();
       }
       catch (Exception e)
       {
          // make sure you observe exceptions in async void
       }
    }
