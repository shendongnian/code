    public class TcpServer
    {
        public void Run(string address, int port)
        {
            var listener = new TcpListener(IPAddress.Parse(address), port);
            listener.Start();
            while (true)
            {
                TcpClient tcpclient = null;
                NetworkStream netstream = null;
                try
                {
                    tcpclient = listener.AcceptTcpClient();
                    Console.WriteLine("Client connected from " + tcpclient.Client.LocalEndPoint.ToString());
                    netstream = tcpclient.GetStream();
                    var responsewriter = new StreamWriter(netstream) { AutoFlush = true };
                    while (true)
                    {
                        if (IsDisconnected(tcpclient))
                            throw new Exception("Client disconnected gracefully");
                        if (netstream.DataAvailable)             // handle scenario where client is not done yet, and DataAvailable is false. This is not part of the tcp protocol.
                        {
                            string request = Read(netstream);
                            Console.WriteLine("Client sent: " + request);
                            responsewriter.Write("You sent: " + request);
                        }
                    }
                }
                catch (Exception ex)
                {
                    netstream.Close();
                    tcpclient.Close();
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private bool IsDisconnected(TcpClient tcp)
        {
            if (tcp.Client.Poll(0, SelectMode.SelectRead))
            {
                byte[] buff = new byte[1];
                if (tcp.Client.Receive(buff, SocketFlags.Peek) == 0)
                    return true;
            }
            return false;
        }
        private string Read(NetworkStream netstream)
        {
            byte[] buffer = new byte[1024];
            int dataread = netstream.Read(buffer, 0, buffer.Length);
            string stringread = Encoding.UTF8.GetString(buffer, 0, dataread);
            return stringread;
        }
    }
