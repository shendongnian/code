        public void CreateSocket()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SocketAsyncEventArgs sockAsync = new SocketAsyncEventArgs();
            sockAsync.Completed += SockAsync_Completed;
            s.ConnectAsync(sockAsync);
        }
        private void SockAsync_Completed(object sender, SocketAsyncEventArgs e)
        {
            //Do stuff with your callback object.
        }
