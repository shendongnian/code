        public static void CheckIfBlocked(ref HtmlDocument htmlDoc, string ypURL, HtmlWeb hw)
        {
            if (htmlDoc.DocumentNode.InnerText.Contains("FORBIDDEN ACCESS!"))
            {
                Console.WriteLine("Getting Blocked");
                Utils.RefreshTor();
                htmlDoc = hw.Load(ypURL, "127.0.0.1", 8118, null, null);
                if (htmlDoc.DocumentNode.InnerText.Contains("FORBIDDEN ACCESS!"))
                {
                    Console.WriteLine("Getting Blocked");
                    Utils.RefreshTor();
                }
            }
        }
        public static void RefreshTor()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9051);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ip);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Unable to connect to server.");
                RefreshTor();
                return;
            }
            server.Send(Encoding.ASCII.GetBytes("AUTHENTICATE \"butt\"\n"));
            byte[] data = new byte[1024];
            int receivedDataLength = server.Receive(data);
            string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
            if (stringData.Contains("250"))
            {
                server.Send(Encoding.ASCII.GetBytes("SIGNAL NEWNYM\r\n"));
                data = new byte[1024];
                receivedDataLength = server.Receive(data);
                stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
                if (!stringData.Contains("250"))
                {
                    Console.WriteLine("Unable to signal new user to server.");
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                    RefreshTor();
                }
            }
            else
            {
                Console.WriteLine("Unable to authenticate to server.");
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                RefreshTor();
            }
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
