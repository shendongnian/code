        private void OnAccept(IAsyncResult iar)
        {
            TcpListener l = (TcpListener) iar.AsyncState;
            TcpClient c;
            try
            {
                c = l.EndAcceptTcpClient(iar);
                // keep listening
                l.BeginAcceptTcpClient(new AsyncCallback(OnAccept), l);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Error accepting TCP connection: {0}", ex.Message);
                // unrecoverable
                _doneEvent.Set();
                return;
            }
            catch (ObjectDisposedException)
            {
                // The listener was Stop()'d, disposing the underlying socket and
                // triggering the completion of the callback. We're already exiting,
                // so just return.
                Console.WriteLine("Listen canceled.");
                return;
            }
            // meanwhile...
            SslStream s = new SslStream(c.GetStream());
            Console.WriteLine("Authenticating...");
            s.BeginAuthenticateAsServer(_cert, new AsyncCallback(OnAuthenticate), s);
        }
