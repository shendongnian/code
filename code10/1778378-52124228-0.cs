        static private void SetupServer() {
        Console.WriteLine($"{DateTime.Now}: Setting up server on {port}...");
        EndPoint remoteEP = new IPEndPoint(IPAddress.Any, port);
        serverSocket.Bind(remoteEP);
        Console.WriteLine($"{DateTime.Now}: Server created successfully");
        serverSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remoteEP,BeginReceive, serverSocket);
    }
    static private void BeginReceive(IAsyncResult ar) {
        EndPoint epSender = new IPEndPoint(IPAddress.Any, port);
        int recv = serverSocket.EndReceiveFrom(ar,epSender);
        byte[] dataBuf = new byte[recv];
        Array.Copy(buffer, dataBuf, recv);
        Console.WriteLine($"{DateTime.Now}: {Encoding.ASCII.GetString(dataBuf)}");
        serverSocket.SendTo(dataBuf,epSender)
        serverSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remoteEP, BeginReceive, serverSocket);
    }
