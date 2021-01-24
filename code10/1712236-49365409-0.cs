    private bool _stopRequested = false;
    private TimeSpan _interval = TimeSpan.FromMinutes(1);
    private readonly object _monitorLock = new object();
    private Thread _thread = null;
    
    constructor()
    {
        ThreadStart threadStart = new ThreadStart(this.DoWork);
         _thread = new Thread(threadStart);
    }
    void DoWork()
    {
        while (!_stopRequested)
        {
           lock(_monitorLock)
           {
               //Do Processing, whilst Checking for whether stop requested has been set. If it has return out.
               Monitor.Wait(_monitorLock, _interval);
           }
        }
    }
    public void RequestStart()
    {
            _stopRequested = false;
            _thread.Start();
     }
        public void RequestStop()
        {
                _stopRequested = true;
                //Lock the monitor object
                lock (_monitorLock)
                {
                    //Pulse the monitor lock to release it
                    Monitor.Pulse(_monitorLock);
                }
        }
