     private void StartProcessing(Socket serverSocket)
    {
        var clientSocket = serverSocket.Accept();
        StartReceiveing(clientSocket);
    }
    
    private void StartReceiveing(Socket clientSocket)
    {
        const int maxBufferSize = 1024;
    
        try
        {
            while (true)
            {
                var buffer = new byte[maxBufferSize];
    
                var bytesRead = clientSocket.Receive(buffer);
    
                if (ClientIsConnected(clientSocket))
                {
                    var actualData = new byte[bytesRead];
    
                    Array.Copy(buffer, actualData, bytesRead);
                    OnDataReceived(actualData);
                }
                else
                {
                    OnDisconnected(clientSocket);
                }
            }
        }
        catch (SocketException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private void OnDisconnected(Socket issuedSocket)
    {
        if (issuedSocket != null)
        {
            issuedSocket.Shutdown(SocketShutdown.Both);
            issuedSocket.Close();
    
            StartProcessing(listener);
        }
    }
    
    private void OnDataReceived(byte[] data)
    {
        //do cool things
    }
    
    private static bool ClientIsConnected(Socket socket)
    {
        return !(socket.Poll(1000, SelectMode.SelectRead) && socket.Available == 0);
    }
