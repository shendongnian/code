            try
            {
                TcpListener tcpListener = new TcpListener(ipAddress, portNumber);
                tcpListener.Start();
            }
            catch(SocketException ex)
            {
                if(ex.ErrorCode == 10048)
                {
                    MessageBox.Show("Port " + portNumber + " is currently in use.");
                }
                return;
            }
