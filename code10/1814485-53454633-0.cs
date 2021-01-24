    var cancellation = new CancellationTokenSource();
    ...
    var listener = new TcpListener(...);
    listener.Start();
    try
    {
        while (!token.IsCancellationRequested)
        {
            var client = await  listener.AcceptTcpClientAsync()
            ...
        }
    }
    finally
    {
        listener.Stop();
    }
    
    // somewhere in another thread
    cancellation.Cancel();
