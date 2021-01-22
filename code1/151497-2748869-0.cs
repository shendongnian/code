    public void Start()
    {
        currentHandledRequests = 0;
        tcpListener = new TcpListener(IPAddress.Any, 10000);
        try
        {
            tcpListener.Start(1100);  // This is the backlog parameter
            while (true)
                DoBeginAcceptTcpClient(tcpListener);
        }
        catch (SocketException)
        {
            // The TcpListener is shutting down, exit gracefully
            CheckBuffer();
            return;
        }
    }
