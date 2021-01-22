    using System.Threading;
    private Thread _thread;
    private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
    private ManualResetEvent _scheduleEvent = new ManualResetEvent(false);
    private System.Timers.Timer _scheduleTimer = new System.Timers.Timer();
    protected override void OnStart(string[] args)
    {
        // Configure the timer.
        _scheduleTimer.AutoReset = false;
        _scheduleTimer.Interval = 120000; // 2 minutes in milliseconds
        _scheduleTimer.Elapsed += delegate { _scheduleEvent.Set(); }
        // Create the thread using anonymous method.
        _thread = new Thread( delegate() {
            // Create the WaitHandle array.
            WaitHandler[] handles = new WaitHandle[] {
                _shutdownEvent,
                _scheduleEvent
            };
            // Start the timer.
            _scheduleTimer.Start();
            // Wait for one of the events to occur.
            while (!_shutdownEvent.WaitOne(0)) {
                switch (WaitHandle.WaitAny(handles)) { 
                   case 0:  // Shutdown Event
                       break;
                   case 1:  // Schedule Event
                       _scheduleTimer.Stop();
                       _scheduleEvent.Reset();
                       ThreadPool.QueueUserWorkItem(PerformScheduledWork, null);
                       break;
                   default:
                       _shutdownEvent.Set(); // should never occur
                }
            }
        } );
        _thread.IsBackground = true;
        _thread.Start();
    }
    protected override void OnStop()
    {
        // Signal the thread to shutdown.
        _shutdownEvent.Set();
        // Give the thread 3 seconds to terminate.
        if (!_thread.Join(3000)) {
            _thread.Abort(); // not perferred, but the service is closing anyway
        }
    }
    private void PerformScheduledWork(object state)
    {
        // Perform your work here, but be mindful of the _shutdownEvent in case
        // the service is shutting down.
        //
        // Reschedule the work to be performed.
         _scheduleTimer.Start();
    }
