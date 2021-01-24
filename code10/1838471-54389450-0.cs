       private TcpClient client;
        private NetworkStream recieveData;
        private Task rx;
        public delegate void DataRecived(string data);
        public event DataRecived OnDataRecived;
        public delegate void ConnectionStatus(bool data);
        public event ConnectionStatus clientConnected;
        public delegate void LogStatus(bool data);
        public event LogStatus loggedIn;
        public delegate void ValueChanged(int value);
        public event ValueChanged newLightValue;
        public string Ip;
        public int Port;
        private bool auth;
        public bool valueInChanging;
     public Client()
        {
           client = new TcpClient();
           rx = new Task(StartReading);
        }
        public async void Connect()
        {
            try
            {
                await client.ConnectAsync(Ip, Port);
                clientConnected(client.Connected);
                rx.Start();                                  
            }
            catch (Exception ex)
            {
                OnDataRecived("Error Connecting" + ex.ToString());
            }
        }
        private void StartReading()
        {
            while (true)
            {
                recieveData = client.GetStream();
                byte[] bytes = new byte[1024];
                Byte[] data = new Byte[256];
                string responseData;
                if (recieveData != null)
                {
                    int bytesRead = recieveData.Read(bytes, 0, bytes.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRead);
                    if (!auth)
                    {
                        OnReceivedMessage(responseData);
                    }
                    else
                    {
                        Feedback(responseData);
                    }
                }
            }           
        }
