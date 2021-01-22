    test_connection("ip", port);
             
    
    public void test_connection(String hostname, int portno) 
            {
                IPAddress ipa = (IPAddress)Dns.GetHostAddresses(hostname)[0];
    
    
                try
                {
                    System.Net.Sockets.Socket sock = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                    sock.Connect(ipa, portno);
                    if (sock.Connected == true)
                    {
                        MessageBox.Show("Port is in use");
                    }
                        
                    sock.Close();
    
                }
               catch (System.Net.Sockets.SocketException ex)
                {
                    if (ex.ErrorCode == 10060) {
                        MessageBox.Show("No connection.");
                    }
    
                }
            
            }
