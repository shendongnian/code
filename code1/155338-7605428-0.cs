    public static bool IsServerUp(string server, int port, int timeout)
        {
            bool isUp;
            try
            {
                using (TcpClient tcp = new TcpClient())
                {
                    IAsyncResult ar = tcp.BeginConnect(server, port, null, null);
                    WaitHandle wh = ar.AsyncWaitHandle;
                    
                    try
                    {
                        if (!wh.WaitOne(TimeSpan.FromMilliseconds(timeout), false))
                        {
                            tcp.EndConnect(ar);
                            tcp.Close();
                            throw new SocketException();
                        }
                        isUp = true;
                        tcp.EndConnect(ar);
                    }
                    finally
                    {
                        wh.Close();
                    }
                } 
            }
            catch (SocketException e)
            {
                LOGGER.Warn(string.Format("TCP connection to server {0} failed.", server), e);
                isUp = false;
            }
            return isUp;
