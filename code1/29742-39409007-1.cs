    internal class Server
    {
        private TcpServer _tcpServer;
        private NetworkStream _stream;        
      
        public void StartServer()
        {
			// fire up a simple Tcp server
            _tcpServer = new TcpServer({serverPort}, "test");
            _tcpServer.ClientConnected += ClientConnected;
        }
		
        private void ClientConnected(object sender, TcpClientConnectedEventArgs e)
        {            
			// an incoming client has been detected ... send the file to that client!
            _stream = e.Client.GetStream();
            SendFileToClient({pathToFile});
        }
        private void SendFileToClient(string pathToFile)
        {
			// open the file as a stream and send in chunks
            using (var fs = new FileStream(pathToFile, FileMode.Open))
            {
                // send header which is file length
                var headerBytes = new byte[4];
                Buffer.BlockCopy(BitConverter.GetBytes(fs.Length + 4), 0, headerBytes, 0, 4);
                _stream.Write(headerBytes, 0, 4);
				// send file in block sizes of your choosing
                var buffer = new byte[100000];
                int bytesRead = 0;
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    _stream.Write(buffer, 0, bytesRead);
                }
                _stream.Flush();
            }
        }
    }
