        public static bool TestOpenPort(int Port)
        {
            var tcpListener = default(TcpListener);
            try
            {
                var ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
                
                tcpListener = new TcpListener(ipAddress, Port);
                tcpListener.Start();
                return true;
            }
            catch (SocketException)
            {
            }
            finally
            {
                if (tcpListener != null)
                    tcpListener.Stop();
            }
            return false;
        }
