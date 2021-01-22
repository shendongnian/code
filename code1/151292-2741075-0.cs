    public IDLServer(System.Net.IPAddress addr,int port)
    {
        Listener = new TcpListener(addr, port);
        Listener.Start();        
        // Use the BeginXXXX Pattern to accept clients asynchronously
        listener.BeginAcceptTcpClient(this.OnAcceptConnection,  listener);
    }
    
    private void OnAcceptConnection(IAsyncResult asyn) 
    {
        // Get the listener that handles the client request.
        TcpListener listener = (TcpListener) asyn.AsyncState;
    
        // Get the newly connected TcpClient
        TcpClient client = listener.EndAcceptTcpClient(asyn);
    
        // Start the client work
        Thread proct = new Thread(new ParameterizedThreadStart(InstanceHandler));
        proct.Start(client);
    
        // Issue another connect, only do this if you want to handle multiple clients
        listener.BeginAcceptTcpClient(this.OnAcceptConnection,  listener);    
    }
