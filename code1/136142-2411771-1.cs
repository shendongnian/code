    private readonly BackgroundWorker worker = new BackgroundWorker ();
    // this is used to signal our main Gui thread that background
    // task has completed
    private readonly AutoResetEvent isWorkerStopped = 
        new AutoResentEvent (false);
    public void SomeFormEventForStartingBackgroundTask ()
    {
        worker.DoWork += BackgroundTask_NeverEnd;
        // simply pass signal as an argument to task
        worker.RunWorkerAsync (isWorkerStopped);
    }
    private void BackgroundTask_NeverEnd (object sender, DoWorkEventArgs e)
    {
        // 1. pull signal from argument
        AutoResetEvent isStopped = (AutoResetEvent)(e.Argument);
        // 2. execute until canceled
        for ( ; !e.Cancel;)
        {
            // keep in mind, this task will *block* main
            // thread until cancel flag is checked again,
            // so if you are, say crunching SETI numbers 
            // here for instance, you could still be blocking
            // a long time. but long time is better than 
            // forever ;)
        }
        // ok, our task has stopped, set signal to 'signaled' state
        // we are complete!
        isStopped.Set ();
    }
    private void App_FormClosing(object sender, FormClosingEventArgs e)     
    {
        // [politely] request termination
        worker.CancelAsync();
        // [politely] wait until background task terminates
        isStopped.WaitOne ();
    }
