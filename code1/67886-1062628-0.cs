    private void connect(string ipAdd,string port)
        {
            try
            {
                SocketAsyncEventArgs e=new SocketAsyncEventArgs();
                
                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                
                IPAddress ip = IPAddress.Parse(serverIp);
                int iPortNo = System.Convert.ToInt16(serverPort);
                IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);
                
                //m_clientSocket.
                e.RemoteEndPoint = ipEnd;
                e.UserToken = m_clientSocket;
                e.Completed+=new EventHandler<SocketAsyncEventArgs>(e_Completed);                
                m_clientSocket.ConnectAsync(e);
                
                if (timer_connection != null)
                {
                    timer_connection.Dispose();
                }
                else
                {
                    timer_connection = new Timer();
                }
                timer_connection.Interval = 2000;
                timer_connection.Tick+=new EventHandler(timer_connection_Tick);
                timer_connection.Start();
            }
            catch (SocketException se)
            {
                lb_connectStatus.Text = "Connection Failed";
                MessageBox.Show(se.Message);
            }
        }
    private void e_Completed(object sender,SocketAsyncEventArgs e)
        {
            lb_connectStatus.Text = "Connection Established";
            WaitForServerData();
        }
        private void timer_connection_Tick(object sender, EventArgs e)
        {
            if (!m_clientSocket.Connected)
            {
                MessageBox.Show("Connection Timeout");
                //m_clientSocket = null;
                
                timer_connection.Stop();
            }
        }
