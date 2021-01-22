        private Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            try
            {
                // Get host related information.
                IPAddress[] ips;
                ips = Dns.GetHostAddresses(server);
                Socket tempSocket = null;
                IPEndPoint ipe = null;
                ipe = new IPEndPoint((IPAddress)ips.GetValue(0), port);
                tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Platform.Log(LogLevel.Info, "Attempting socket connection to " + ips.GetValue(0).ToString() + " on port " + port.ToString());
                tempSocket.Connect(ipe);
                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    s.SendTimeout = Coordinate.HL7SendTimeout;
                    s.ReceiveTimeout = Coordinate.HL7ReceiveTimeout;
                }
                else
                {
                    return null;
                }
                return s;
            }
            catch (Exception e)
            {
                Platform.Log(LogLevel.Error, "Error creating socket connection to " + server + " on port " + port.ToString());
                Platform.Log(LogLevel.Error, "The error is: " + e.ToString());
                if (g_NoOutputForThreading == false)
                    rtbResponse.AppendText("Error creating socket connection to " + server + " on port " + port.ToString());
                return null;
            }
        }
