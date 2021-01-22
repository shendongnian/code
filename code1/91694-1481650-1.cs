    private volatile bool _threadRunning = false;
    private ManualResetEvent _signal = new ManualResetEvent(false);
    private Thread _thread;
    private void OnButtonClick(object sender, EventArgs e)
    {
        if (!_threadRunning) {
            // Reset the 'signal' event.
            _signal.Reset();
            // Build your thread parameter here.
            object param = ;
            // Create the thread.
            _thread = new Thread(ExecuteThreadLogicConditionally(param));
            // Make sure the thread shuts down automatically when UI closes
            _thread.IsBackground = true;
            // Start the thread.
            _thread.Start();
            // Prevent another thread from being started.
            _threadRunning = true;
        } else {
            // Signal the thread to stop.
            _signal.Set();
            // DO NOT JOIN THE THREAD HERE!  If the thread takes a while
            // to exit, then your UI will be frozen until it does.  Just
            // set the signal and move on.
        }
    }
    // If the thread is intended to execute its logic over and over until
    // stopped, use this callback.
    private void ExecuteThreadLogicUntilStopped(object param)
    {
        // Use a while loop to prevent the thread from exiting too early.
        while (!_signal.WaitOne(0)) {
            // Put your thread logic here...
        }
        // Set the flag so anther thread can be started.
        _threadRunning = false;
    }
    // If the thread logic is to be executed once and then wait to be
    // shutdown, use this callback.
    private void ExecuteThreadLogicOnce(object param)
    {
        // Put your thread logic here...
        //
        // Now wait for signal to stop.
        _signal.WaitOne();
        // Set the flag so another thread can be started.
        _threadRunning = false;
    }
    // If the thread needs to be stopped at any point along the way, use
    // this callback.  The key here is to 'sprinkle' checks of the 'signal'
    // to see if the thread should stop prematurely.
    private void ExecuteThreadLogicConditionally(object param)
    {
        if (_signal.WaitOne(0)) { _threadRunning = false; return; }
        // Execute small chunk of logic here...
        if (_signal.WaitOne(0)) { _threadRunning = false; return; }
        // Execute another small chuck of logic here...
        if (_signal.WaitOne(0)) { _threadRunning = false; return; }
        // Continue this pattern through the method.
    }
