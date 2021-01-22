    private void SendFileToSocket(string fileName)
    {
        Socket socket = new Socket(
            AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        using (socket)
        {
            socket.Connect("server.domain.com", 12345);
            using (NetworkStream networkStream = new NetworkStream(socket))
            using (FileStream fileStream = File.OpenRead(fileName))
            {
                byte[] buffer = new byte[32768];
                while (true)
                {
                    int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    networkStream.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
