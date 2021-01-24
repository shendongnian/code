    private byte[] ListenForIncommingRequests()
    {
        try
        {           
            tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 35800);
            tcpListener.Start();
            Debug.Log("Server is listening");
            Byte[] bytes = new Byte[1024];
            while (true)
            {
                using (connectedTcpClient = tcpListener.AcceptTcpClient())
                {               
                    using (NetworkStream stream = connectedTcpClient.GetStream())
                    {
                        int length;                         
                        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            var incommingData = new byte[length];
                            Array.Copy(bytes, 0, incommingData, 0, length); 
                            Loader = incommingData;
                            string clientMessage = Encoding.ASCII.GetString(incommingData);
                            Debug.Log("client message received as: " + clientMessage);                            
    
                        }
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("SocketException " + socketException.ToString());
        }
        return bytes;
    }
