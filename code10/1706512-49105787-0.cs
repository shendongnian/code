    class MySocket {
        byte[] buffer = new byte[4];
        void Recv() {
            _socket.BeginReceive(buffer, 0, 4, 0, new AsyncCallback(RecvCallback), null);
        }
        private void RecvCallback(IAsyncResult ar)
        {
            int n = _socket.EndReceive(ar);
            if(n == 0)
                // use this.buffer
        }
    }
