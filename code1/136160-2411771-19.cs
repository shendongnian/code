    private Thread worker = null;
    // this time, 'Thread' provides all synchronization
    // constructs required for main thread to synchronize
    // with background task. however, in the interest of
    // giving background task a chance to terminate gracefully
    // we supply it with this cancel signal
    private readonly AutoResetEvent isCanceled = new AutoResentEvent (false);
    public void SomeFormEventForStartingBackgroundTask ()
    {
        worker = new Thread (BackgroundTask_HotelCalifornia);
        worker.IsBackground = true;
        worker.Name = "Some Background Task"; // always handy to name things!
        worker.Start ();
    }
    private void BackgroundTask_HotelCalifornia ()
    {
        // inspect cancel signal, no wait period
        // 
        // NOTE: so cheating here a bit, this is an instance variable
        // but could as easily be supplied via parameterized thread
        // start delegate
        for ( ; !isCanceled.WaitOne (0);)
        {
        }
    }
    private void App_FormClosing(object sender, FormClosingEventArgs e)     
    {
        // [politely] request termination
        isCanceled.Set ();
        // [politely] wait until background task terminates
        TimeSpan gracePeriod = TimeSpan.FromMilliseconds(100);
        bool isStoppedGracefully = worker.Join (gracePeriod);
        if (!isStoppedGracefully)
        {
            // wipe them out, all of them.
            worker.Abort ();
        }
    }
