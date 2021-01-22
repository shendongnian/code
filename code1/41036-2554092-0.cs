    /// <summary>
    /// Executes the specified method in a delayed context by utilizing
    /// a temporary timer.
    /// </summary>
    /// <param name="millisecondsToDelay">The milliseconds to delay.</param>
    /// <param name="methodToExecute">The method to execute.</param>
    public static void DelayedExecute(int millisecondsToDelay, MethodInvoker methodToExecute)
    {
        Timer timer = new Timer();
        timer.Interval = millisecondsToDelay;
        timer.Tick += delegate
                          {
                              // This will be executed on a single (UI) thread, so lock is not necessary
                              // but multiple ticks may have been queued, so check for enabled.
                              if (timer.Enabled)
                              {
                                  timer.Stop();
    
                                  methodToExecute.Invoke();
    
                                  timer.Dispose();
                              }
                          };
    
        timer.Start();
    }
