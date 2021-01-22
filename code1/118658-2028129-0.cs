    var tcpConnectionMade = new AutoResetEvent(false);
    System.Threading.ThreadPool.QueueUserWorkItem(delegate 
    {
        // listen for TCP connection
        ...
        // once connected
        tcpConnectionMade.Set();
    });
    // wait for TCP connection
    WaitHandle.WaitOne(tcpConnectionMade);
    // do something when connected...
