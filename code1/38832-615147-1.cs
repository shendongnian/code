     class HSTcpClient
    {
        private TcpClient _client;
        private IPAddress _address;
        private int _port;
        private IPEndPoint _endPoint;
        private bool _disposed;
        public HSTcpClient(IPAddress address, int port)
        {
            _address = address;
            _port = port;
            _endPoint = new IPEndPoint(_address, _port);
        }
        public void SendForwardedClientMessage(int senderId, int receiverId, int hsId)
        {
            SendMessage(senderId.ToString() + ":" + receiverId.ToString() + ":" + hsId.ToString());
        }
        public void SendUpdatedCGBMessage()
        {
            SendMessage("Update your CGB you clowns");
        }
        public void SendMessage(string msg)
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(_endPoint);
                // Get the bytes to send for the message
                byte[] bytes = Encoding.ASCII.GetBytes(msg);
                // Get the stream to talk to the server on
                using (NetworkStream ns = _client.GetStream())
                {
                    // Send message
                    Trace.WriteLine("Sending message to server: " + msg);
                    ns.Write(bytes, 0, bytes.Length);
                    // Get the response
                    // Buffer to store the response bytes
                    bytes = new byte[1024];
                    // Display the response
                    int bytesRead = ns.Read(bytes, 0, bytes.Length);
                    string serverResponse = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                    Trace.WriteLine("Server said: " + serverResponse);
                }
            }
            catch (SocketException se)
            {
                Trace.WriteLine("There was an error talking to the server: " +
                    se.ToString());
            }
            finally
            {
                Dispose();
            }
        }
        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_client != null)
                        _client.Close();
                }
                _disposed = true;
            }
        }
        #endregion
    }
