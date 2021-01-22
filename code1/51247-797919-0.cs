    private class WinSock
    {
        private Socket sock;
        private byte[] data;
        .....
        // Read at most length bytes of data to buffer starting at offset
        // and return the number of bytes read
        public int Read(byte[] buffer, int offset, int length)
        {
            // ...
        }
    }
    WinSock ws = new WinSock();
    var data = new byte[2058];
    int bytesRead = ws.Read(data, 0, data.Length);
