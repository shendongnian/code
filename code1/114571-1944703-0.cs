    /// <summary>
    /// Thread safe queue of client ids
    /// </summary>
    internal class FileSender
    {
        /// <summary>
        /// A write operation have completed 
        /// </summary>
        /// <param name="ar"></param>
        private void OnWriteCompleted(IAsyncResult ar)
        {
            // We passed the context to this method, cast it back
            var context = (ClientContext) ar.AsyncState;
            // end the write
            context.TcpClient.GetStream().EndWrite(ar);
            // we've completed.
            if (context.BytesSent >= context.FileStream.Length)
            {
                // notify any listener
                Completed(this, new CompletedEventArgs(context.RemoteEndPoint, context.FileStream.Name));
                context.TcpClient.Close();
                return;
            }
            // Send more data from the file to the server.
            int bytesRead = context.FileStream.Read(context.Buffer, 0, context.Buffer.Length);
            context.BytesSent += bytesRead;
            context.TcpClient.GetStream().BeginWrite(context.Buffer, 0, bytesRead, OnWriteCompleted, context);
        }
        /// <summary>
        /// Send a file
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="fullPath"></param>
        public void SendFile(IPEndPoint endPoint, string fullPath)
        {
            // Open a stream to the file
            var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            // Create a client and connect to remote end
            var client = new TcpClient();
            client.Connect(endPoint);
            // Context is used to keep track of this client
            var context = new ClientContext
                              {
                                  Buffer = new byte[65535],
                                  FileStream = stream,
                                  TcpClient = client,
                                  RemoteEndPoint = endPoint
                              };
            // read from file stream
            int bytesRead = stream.Read(context.Buffer, 0, context.Buffer.Length);
            // and send the data to the server
            context.BytesSent += bytesRead;
            client.GetStream().BeginWrite(context.Buffer, 0, bytesRead, OnWriteCompleted, context);
        }
        /// <summary>
        /// File transfer have been completed
        /// </summary>
        public event EventHandler<CompletedEventArgs> Completed = delegate { };
        #region Nested type: ClientContext
        /// <summary>
        /// Used to keep track of all open connections
        /// </summary>
        private class ClientContext
        {
            /// <summary>
            /// Gets or sets buffer used to send file
            /// </summary>
            public byte[] Buffer { get; set; }
            /// <summary>
            /// Gets or sets number of bytes sent.
            /// </summary>
            public int BytesSent { get; set; }
            /// <summary>
            /// Gets or sets file to send
            /// </summary>
            public FileStream FileStream { get; set; }
            public IPEndPoint RemoteEndPoint { get; set; }
            /// <summary>
            /// Gets or sets client sending the file
            /// </summary>
            public TcpClient TcpClient { get; set; }
        }
        #endregion
    }
    internal class CompletedEventArgs : EventArgs
    {
        public CompletedEventArgs(IPEndPoint endPoint, string fullPath)
        {
            EndPoint = endPoint;
            FullPath = fullPath;
        }
        public IPEndPoint EndPoint { get; private set; }
        public string FullPath { get; private set; }
    }
