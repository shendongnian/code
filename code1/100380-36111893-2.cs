        public SmtpConnectorWithoutSsl(string smtpServerAddress, int port) : base(smtpServerAddress, port) {
            IPHostEntry hostEntry = Dns.GetHostEntry(smtpServerAddress);
            IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], port);
            _socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //try to connect and test the rsponse for code 220 = success
            _socket.Connect(endPoint);
        }
        ~SmtpConnectorWithoutSsl() {
            try {
                if (_socket != null) {
                    _socket.Close();
                    _socket.Dispose();
                    _socket = null;
                }
            } catch (Exception) {
                ;
            }
        }
        public override bool CheckResponse(int expectedCode) {
            while (_socket.Available == 0) {
                System.Threading.Thread.Sleep(100);
            }
            byte[] responseArray = new byte[1024];
            _socket.Receive(responseArray, 0, _socket.Available, SocketFlags.None);
            string responseData = Encoding.UTF8.GetString(responseArray);
            int responseCode = Convert.ToInt32(responseData.Substring(0, 3));
            if (responseCode == expectedCode) {
                return true;
            }
            return false;
        }
        public override void SendData(string data) {
            byte[] dataArray = Encoding.UTF8.GetBytes(data);
            _socket.Send(dataArray, 0, dataArray.Length, SocketFlags.None);
        }
    }
