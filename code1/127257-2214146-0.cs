    <code>
        /// <summary>
        /// Gets the contents of a page, using IP address not host name
        /// </summary>
        /// <param name="host">The IP of the host</param>
        /// <param name="port">The Port to connect to</param>
        /// <param name="path">the path to the file request (with leading /)</param>
        /// <returns>Page Contents in string</returns>
        private string GetWebPage(string host, int port,string path)
        {
            string getString = "GET "+path+" HTTP/1.1\r\nHost: www.Me.mobi\r\nConnection: Close\r\n\r\n";
            Encoding ASCII = Encoding.ASCII;
            Byte[] byteGetString = ASCII.GetBytes(getString);
            Byte[] receiveByte = new Byte[256];
            Socket socket = null;
            String strPage = null;
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(host), port);
                socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ip);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Source:" + ex.Source);
                Console.WriteLine("Message:" + ex.Message);
                MessageBox.Show("Message:" + ex.Message);
            }
            socket.Send(byteGetString, byteGetString.Length, 0);
            Int32 bytes = socket.Receive(receiveByte, receiveByte.Length, 0);
            strPage = strPage + ASCII.GetString(receiveByte, 0, bytes);
            while (bytes > 0)
            {
                bytes = socket.Receive(receiveByte, receiveByte.Length, 0);
                strPage = strPage + ASCII.GetString(receiveByte, 0, bytes);
            }
            socket.Close();
            return strPage;
        }
