    public Server(IHandler handler, int port)
    {
        this.handler = handler;
        IPAddress address = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
        listener = new TcpListener(address, port);
        running = false;
        _event = new AutoResetEvent(false);
    }
    
    public void Start()
    {
        Thread thread = new Thread(ThreadStart);
        thread.Start();
    }
    
    public void Stop()
    {
        listener.Stop();
        running = false;
        _event.Set();
    }
    
    void ThreadStart()
    {
        if (!running)
        {
            listener.Start();
            running = true;
            while (running)
            {
                try
                {
                    listener.BeginAcceptTcpClient(new AsyncCallback(Accept), listener);
                    _event.WaitOne();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    
    void Accept(IAsyncResult result)
    {
        // Let the server continue listening
        _event.Set();
        if (running)
        {
            TcpListener localListener = (TcpListener) result.AsyncState;
            using (TcpClient client = localListener.EndAcceptTcpClient(result))
            {
                handler.Handle(client.GetStream());
            }
        }
    }
