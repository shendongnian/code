    class Server
    {
        private Socket socket;
        private List<Socket> connections;
        private volatile Boolean endAccept;
        
        // glossing over some code.
    
    
        /// <summary></summary>
        public void Accept()
        {
            EventHandler<SocketAsyncEventArgs> completed = null;
            SocketAsyncEventArgs args = null;
    
            completed = new EventHandler<SocketAsyncEventArgs>((s, e) =>
            {
                if (e.SocketError != SocketError.Success)
                {
                    // handle
                }
                else
                {
                    connections.Add(e.AcceptSocket);
                    ThreadPool.QueueUserWorkItem(AcceptNewClient, e.AcceptSocket);
                }
    
                e.AcceptSocket = null;
                if (endAccept)
                {
                    args.Dispose();
                }
                else if (!socket.AcceptAsync(args))
                {
                    completed(socket, args);
                }
            });
    
            args = new SocketAsyncEventArgs();
            args.Completed += completed;
    
            if (!socket.AcceptAsync(args))
            {
                completed(socket, args);
            }
        }
        
        public void AcceptNewClient(Object state)
        {
            var socket = (Socket)state;
            // proccess        
        }        
    }
