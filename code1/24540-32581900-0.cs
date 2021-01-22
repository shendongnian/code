    public class Worker
    {
     ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
     ManualResetEvent _pauseEvent = new ManualResetEvent(true);
     Thread _thread;
     
    public Worker() { }
     
    public void Start()
     {
     _thread = new Thread(DoWork);
     _thread.Start();
     Console.WriteLine("Thread started running");
     }
     
    public void Pause()
     {
     _pauseEvent.Reset();
     Console.WriteLine("Thread paused");
     }
     
    public void Resume()
     {
     _pauseEvent.Set();
     Console.WriteLine("Thread resuming ");
     }
     
    public void Stop()
     {
     // Signal the shutdown event
     _shutdownEvent.Set();
     Console.WriteLine("Thread Stopped ");
     
    // Make sure to resume any paused threads
     _pauseEvent.Set();
     
    // Wait for the thread to exit
     _thread.Join();
     }
     
    public void DoWork()
     {
     while (true)
     {
     _pauseEvent.WaitOne(Timeout.Infinite);
     
    if (_shutdownEvent.WaitOne(0))
     break;
     
    // Do the work..
     Console.WriteLine("Thread is running");
     
     }
     }
    }
