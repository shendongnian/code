       public partial class Form1 : Form
        {
            Socket _clientSocket;
            public Form1()
            {
                InitializeComponent();
            }
    
            const int buffSize = 1024;
            byte[] receivedBuf = new byte[buffSize];
            Socket listenerSock;
            Socket handlerSock;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
    
                listenerSock = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listenerSock.Bind(localEndPoint);
                listenerSock.Listen(10);
                listenerSock.BeginAccept(ServerAcceptAsync, null);
                _clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _clientSocket.Connect(localEndPoint);
                _clientSocket.BeginReceive(receivedBuf, 0, buffSize, SocketFlags.None, ReceiveData, null);
            }
    
            private void ServerAcceptAsync(IAsyncResult ar)
            {
                handlerSock = listenerSock.EndAccept(ar);
            }
    
            private void ReceiveData(IAsyncResult ar)
            {
                //try
                //{
                Debug.WriteLine("received data");
                    int received = _clientSocket.EndReceive(ar);
                    if (received == 0)
                    {
                        return;
                    }
                    Array.Resize(ref receivedBuf, received);
                    string text = Encoding.Default.GetString(receivedBuf);
                Debug.WriteLine(text);
                    if (text == "Server: -O")
                    {
                        Thread NT = new Thread(() =>
                        {
                            this.BeginInvoke((Action)delegate ()
                            {
                                textBox1.Text = "Guest";
                                this.Hide();
                                _clientSocket.Close();
                                //Usertimer us = new Usertimer(textBox1.Text);
                                //us.Show();
                            });
                        });
                        NT.Start();
                    }
                    Array.Resize(ref receivedBuf, _clientSocket.ReceiveBufferSize);
                    //AppendtoTextBox(text);
                    _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), null);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var message = Encoding.UTF8.GetBytes("Server: -O");
                handlerSock.Send(message);
            }
        }
