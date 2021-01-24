    class MySocket {
        byte[] buffer = new byte[4];
        private int totalNumberOfBytes;
        void Recv() {
            _socket.BeginReceive(buffer, 0, 4, 0, new AsyncCallback(RecvCallback), null);
        }
        private void RecvCallback(IAsyncResult ar)
        {
            int n = _socket.EndReceive(ar);
            // Needs synchronization if multiple operations happen simultaneously
            totalNumberOfBytes += n; 
            if(n == 0)
                // use this.buffer
        }
    }
