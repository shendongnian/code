      IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
      try {
        TcpListener tcpListener = new TcpListener(ipAddress, 666);
        tcpListener.Start();
      }
      catch (SocketException ex) {
        MessageBox.Show(ex.Message, "kaboom");
      }
