    private readonly BackgroundWorker worker = new BackgroundWorker ();
    // this is used to signal our main Gui thread that background
    // task has completed
    private readonly AutoResetEvent isWorkerStopped = 
        new AutoResentEvent (false);
    public void SomeFormEventForStartingBackgroundTask ()
    {
        worker.DoWork += BackgroundTask_HotelCalifornia;
        worker.RunWorkerCompleted += BackgroundTask_Completed;
        worker.RunWorkerAsync ();
    }
    private void BackgroundTask_HotelCalifornia (object sender, DoWorkEventArgs e)
    {
        // execute until canceled
        for ( ; !e.Cancel;)
        {
            // keep in mind, this task will *block* main
            // thread until cancel flag is checked again,
            // so if you are, say crunching SETI numbers 
            // here for instance, you could still be blocking
            // a long time. but long time is better than 
            // forever ;)
        }
    }
    private void BackgroundTask_Completed (
        object sender, 
        RunWorkerCompletedEventArgs e)
    {
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
