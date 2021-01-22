    private readonly Queue<Socket> sockets = new Queue<Socket>();
    private readonly object locker = new object();
    private readonly TimeSpan sleepTimeSpan = new TimeSpan(1000);
    private volatile Boolean terminate;
    
    private void HandleRequests() 
    {
        Socket socket = null;
        while (!terminate)
        {
            lock (locker)
            {
                socket = null;
                if (sockets.Count > 0)
                {
                    socket = sockets.Dequeue();
                }
            }
    
            if (socket != null)
            {
                // process
            }
    
            Thread.Sleep(sleepTimeSpan);
        }   
    }
