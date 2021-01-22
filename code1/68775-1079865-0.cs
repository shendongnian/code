            private bool TestPort(string ipString,int port)
            {
                IPAddress ip = IPAddress.Parse(ipString);
                bool test = false;
                try
                {
                    System.Net.Sockets.Socket s = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    s.Connect(ip, port);
                    if (s.Connected == true)
                        test = true;
                    s.Close();
                }
                catch (SocketException ex)
                {
                        test = false;
                }
                return test;
            }
