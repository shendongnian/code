    private static async Task Listen(TcpListener listener)
    {
        //Start listening
        listener.Start();
        Console.WriteLine("Waiting for a connection...\n");
        //Accept connection
        TcpClient client = listener.AcceptTcpClient();
        await Task.Delay(60000); // async wait for 1 minute
        listener.Stop();
        //CHECK
        Console.WriteLine("Accepted the connection\n");
        ClientHandle(client);
    }
