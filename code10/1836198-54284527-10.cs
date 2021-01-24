    using System;
    using System.Threading;
    using System.Windows.Forms; 
    namespace BarcodeReceivingApp { 
        public class TelnetConnection { 
            private Thread _readWriteThread;
            private TcpClient _client;
            private NetworkStream _networkStream;
            private string _hostname;
            private int _port;
            private Form foo;
            public TelnetConnection(string hostname, int port)
            {
                this._hostname = hostname;
                this._port = port;
            }
            public void ServerSocket(string ip, int port,Form f)
            {
                this.foo = f;
                try
                {
                    _client = new TcpClient(ip, port);         
                }
                catch (SocketException)
                {
                    MessageBox.Show(@"Failed to connect to server");
                    return;
                }
                _networkStream = _client.GetStream();
                _readWriteThread = new Thread(ReadWrite());
                _readWriteThread.Start();
            }  
            public void ReadWrite()
            {
                while (true)
                {
                    var command = "test";
                    if (command == "STOP1")
                        break;
                    //write(command);
                     var received = Read();
                     if (foo.lst_BarcodeScan.InvokeRequired)
                     {
                             foo.lst_BarcodeScan.Invoke(new MethodInvoker(delegate {foo.lst_BarcodeScan.Items.Add(received);}));
                     }
                }
            }
        
            public string Read()
            {
                byte[] data = new byte[1024];
                var received = "";
                var size = _networkStream.Read(data, 0, data.Length);
                received = Encoding.ASCII.GetString(data, 0, size);
                return received;
            }
            public void CloseConnection()
            {
                _networkStream.Close();
                _client.Close();
            }
        }
    }
