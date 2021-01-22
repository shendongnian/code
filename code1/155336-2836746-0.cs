    bool IsListening(string server, int port)
    {
        using(TcpClient client = new TcpClient())
        {
            try
            {
                client.Connect(server, port);
            }
            catch(SocketException)
            {
                return false;
            }
            client.Close();
            return true;
        }
    }
