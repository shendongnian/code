    private static void Listen(TcpListener listener)
    {        
        //Start listening
        listener.Start();
        var timerTimer = new Timer((state) => { listener.Stop(); }, null, 60000, Timeout.Infinite);
        Console.WriteLine("Waiting for a connection...\n");
        //Accept connection
        TcpClient client = listener.AcceptTcpClient();
        //CHECK
        Console.WriteLine("Accepted the connection\n");
        ClientHandle(client);
    }
