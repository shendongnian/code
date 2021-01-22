        private void AcceptTcpClientCallback(IAsyncResult ar)
        {
            var listener = (TcpListener)ar.AsyncState;
            
            //Sometimes the socket is null and somethimes the socket was set
            if (listener.Server == null || !listener.Server.IsBound)
                return;
            TcpClient client = null;
            try
            {
                client = listener.EndAcceptTcpClient(ar);
            }
            catch (SocketException ex)
            {
                //the client is corrupt
                OnError(ex);
            }
            catch (ObjectDisposedException)
            {
                //Listener canceled
                return;
            }
            //Get the next Client
            listener.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallback), listener);
            if (client == null)
                return; //Abort if there was an error with the client
            
            MyConnection connection = null;
            try
            {
                //Client-Protocoll init
                connection = Connect(client.GetStream()); 
            }
            catch (Exception ex)
            {
                //The client is corrupt/invalid
                OnError(ex);
                
                client.Close();
            }            
        }
