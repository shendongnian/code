     private void Connectwithserver(ref TcpClient client)
        {
            try
            {
                 //this is server ip and server listen port
                server = new TcpClient("192.168.100.7", 8080);
            }
            catch (SocketException ex)
            {
                //exceptionsobj.WriteException(ex);
                Thread.Sleep(TimeSpan.FromSeconds(10));
                RunBoTClient();
            }
        }
     byte[] data = new byte[1024];
        string stringData;
        TcpClient client;
        private void RunClient()
        {
             NetworkStream ns;
            Connectwithserver(ref client);
             while (true)
            {
                ns = client.GetStream();
                //old
                // ns.ReadTimeout = 50000;
                //old
                ns.ReadTimeout = 50000;
                ns.WriteTimeout = 50000;
                int recv = default(int);
                try
                {
                    recv = ns.Read(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    //exceptionsobj.WriteException(ex);
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                   //try to reconnect if server not respond 
                    RunBoTClient();
                }
            }
        }
