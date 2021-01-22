    private class AsyncState
    {
        public NetworkStream ns;
        public ManualResetEvent e;
        public byte[] b;
        public String strReadXML;
    }
    public void Run()
    {
        TcpClient client ;//= ...
        NetworkStream networkStream = client.GetStream();
        byte[] buffer = new byte[1024];
        var completedEvent = new ManualResetEvent(false);
        networkStream.BeginRead(buffer, 0, buffer.Length,
                                AsyncRead,
                                new AsyncState
                                {
                                    b = buffer,
                                    ns = networkStream,
                                    e = completedEvent,
                                    strReadXML = ""
                                });
        // do other stuff here. ...
        // finally, wait 120s for the reading to complete
        bool success = completedEvent.WaitOne(1200*100, false);
        if (!success)
        {
            client.Close();
        }
    }
    private void AsyncRead(IAsyncResult ar)
    {
        AsyncState state = ar as AsyncState;
        int n = state.ns.EndRead(ar);
        if (n == 0)
        {
            // no more bytes to read
            // signal completion
            state.e.Set();
            return;
        }
        // state.buffer now contains the bytes read
        string s = System.Text.Encoding.Default.GetString(state.b);
        state.strReadXML = state.strReadXML + s.Replace("\0", string.Empty);
        if (state.strReadXML.EndsWith(">"))
        {
            // got the "end".  signal completion
            state.e.Set();
            return;
        }
        // read again
        state.ns.BeginRead(state.b, 0, state.b.Length, AsyncRead, state);
    }
