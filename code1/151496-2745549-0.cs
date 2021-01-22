    static WaitCallback handleTcpRequest = new WaitCallback(HandleTcpRequest);
    static void Main()
    {
        var e = new SocketAsyncEventArgs();
        e.Completed += new EventHandler<SocketAsyncEventArgs>(e_Completed);
        var socket = new Socket(
            AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Bind(new IPEndPoint(IPAddress.Loopback, 8181));
        socket.Listen((int)SocketOptionName.MaxConnections);
        socket.AcceptAsync(e);
        Console.WriteLine("--ready--");
        Console.ReadLine();
        socket.Close();
    }
    static void e_Completed(object sender, SocketAsyncEventArgs e)
    {
        var socket = (Socket)sender;
        ThreadPool.QueueUserWorkItem(handleTcpRequest, e.AcceptSocket);
        e.AcceptSocket = null;
        socket.AcceptAsync(e);
    }
    static void HandleTcpRequest(object state)
    {
        var socket = (Socket)state;
        Thread.Sleep(100); // do work
        socket.Close();
    }
