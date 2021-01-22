    public MainForm()
    {
        InitializeComponents();
        StartListener();
    }
    private TcpListener _listener;
    private Thread _listenerThread;
    private void StartListener()
    {
        _listenerThread = new Thread(RunListener);
        _listenerThread.Start();
    }
    private void RunListener()
    {
        _listener = new TcpListener(IPAddress.Any, 8080);
        _listener.Start();
        while(true)
        {
            TcpClient client = _tcpListener.AcceptClient();
            this.Invoke(
                new Action(
                    () =>
                    {
                        textBoxLog.Text += string.Format("\nNew connection from {0}", client.Client.RemoteEndPoint);
                    }
                ));;
            ThreadPool.QueueUserWorkItem(ProcessClient, client);
        }
    }
    private void ProcessClient(object state)
    {
        TcpClient client = state as TcpClient;
        // Do something with client
        // ...
    }
