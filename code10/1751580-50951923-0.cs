    /// <summary>
    ///     OnStartup is called to raise the Startup event. The developer will typically override this method
    ///     if they want to take action at startup time ( or they may choose to attach an event).
    ///     This method will be called once when the application begins, once that application's Run() method
    ///     has been called.
    /// </summary>
    /// <param name="e">The event args that will be passed to the Startup event</param>
    protected virtual void OnStartup(StartupEventArgs e)
    {
        // Verifies that the calling thread has access to this object.
        VerifyAccess();
 
        StartupEventHandler handler = (StartupEventHandler)Events[EVENT_STARTUP];
        if (handler != null)
        {
            handler(this, e);
        }
    }
