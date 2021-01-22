    public void DoTcpConnection()
        {
            string url = "www.msn.com";
            bool res = GPRSConnection.Setup("http://" + url + "/");
            if (res)
            {
                TcpClient tc = new TcpClient(url, 80);
                NetworkStream ns = tc.GetStream();
                byte[] buf = new byte[100];
                ns.Write(buf, 0, 100);
                tc.Client.Shutdown(SocketShutdown.Both);
                ns.Close();
                tc.Close();
                MessageBox.Show("Wrote 100 bytes");
            }
            else
            {
                MessageBox.Show("Connection establishment failed");
            }
        }
