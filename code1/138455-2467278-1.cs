        private class AsyncState
        {
            public NetworkStream ns;
            public ManualResetEvent e;
            public byte[] b;
        }
        public void Run()
        {
            NetworkStream networkStream = ...;
            byte[] buffer = new byte[1024];
            var completedEvent = new ManualResetEvent(false);
            networkStream.BeginRead(buffer, 0, buffer.Length,
                                    AsyncRead,
                                    new AsyncState
                                    {
                                        b = buffer,
                                        ns = networkStream,
                                        e = completedEvent
                                    });
            // do other stuff here. ...
            // finally, wait for the reading to complete
            completedEvent.WaitOne();
        }
        private void AsyncRead(IAsyncResult ar)
        {
            AsyncState state = ar as AsyncState;
            int n = state.ns.EndRead(ar);
            if (n == 0)
            {
                // signal completion
                state.e.Set();
                return;
            }
            // state.buffer now contains the bytes read
            // do something with it here...
            // for example, dump it into a filesystem file. 
            // read again
            state.ns.BeginRead(state.b, 0, state.b.Length, AsyncRead, state);
        }
