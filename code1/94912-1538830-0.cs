    private void BeginReceive(Socket socket)
        {
            Contract.Requires(socket != null, "socket");
            SocketEventArgs e = SocketBufferPool.Instance.Alloc();
            e.Socket = socket;
            e.Completed += new EventHandler<SocketEventArgs>(this.HandleIOCompleted);
            if (!socket.ReceiveAsync(e.AsyncEventArgs)) {
                this.HandleIOCompleted(null, e);
            }
        }
