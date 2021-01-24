    private void Listen(int port)
    {
        try
        {
            // Perform a blocking call to accept requests.
            // You could also user server.AcceptSocket() here.
            var client = _server.AcceptTcpClient();
            // Get a stream object for reading and writing
            var stream = client.GetStream();
            var pLength = new byte[8];          
            // Loop to receive all the data sent by the client.
            while(_running)
            {
                if(!stream.DataAvailable && stream.Read(pLength, 0, 8) <= 0)
                    continue;            
                var nOfBytes = (int) BitConverter.ToDouble(pLength, 0);
                pLength = new byte[8];
                if (nOfBytes <= 0) 
                {
                    continue;
                }
                var localBytes = new byte[nOfBytes];
                var reader = new BinaryReader(stream);
                ProcessData(reader);
            }
            // Shutdown and end connection
            client.Close();
        }
        catch (SocketException e)
        {
            _errorBool = true;
            _errorString = "Port: " + port + "\n" + e.Message + e.StackTrace;
        }
        finally
        {
            // Stop listening for new clients.
            _server.Stop();
        }
    }
