    public static void RunMessageLoop(Func<Task> action)
    {
      var originalContext = SynchronizationContext.Current;
      Exception exception = null;
      try
      {
        SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext());
    
        action.Invoke().ContinueWith(t =>
        {
          exception = t.Exception;
        }, TaskContinuationOptions.OnlyOnFaulted).ContinueWith(t => Dispatcher.ExitAllFrames(),
          TaskScheduler.FromCurrentSynchronizationContext());
    
        Dispatcher.Run();
      }
      finally
      {
        SynchronizationContext.SetSynchronizationContext(originalContext);
      }
      if (exception != null) throw exception;
    }
