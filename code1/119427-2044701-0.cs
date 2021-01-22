    public void SendData(string zpl)
    {
        NetworkStream ns = null;
        Socket socket = null;
    
        try
        {
            if (printerIP == null)
            {
                /* IP is a string property for the printer's IP address. */
                /* 6101 is the common port of all our Zebra printers. */
                printerIP = new IPEndPoint(IPAddress.Parse(IP), 6101);  
            }
    
            socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
            socket.Connect(printerIP);
    
            ns = new NetworkStream(socket);
    
            byte[] toSend = Encoding.ASCII.GetBytes(zpl);
            ns.Write(toSend, 0, toSend.Length);
        }
        finally
        {
            if (ns != null)
                ns.Close();
    
            if (socket != null && socket.Connected)
                socket.Close();
        }
    }
