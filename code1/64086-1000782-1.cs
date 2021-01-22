    private bool isRealDomain(string inputEmail)
    {
        bool isReal = false;
        try
        {
            string[] host = (inputEmail.Split('@'));
            string hostname = host[1];
            IPHostEntry IPhst = Dns.GetHostEntry(hostname);
            IPEndPoint endPt = new IPEndPoint(IPhst.AddressList[0], 25);
            Socket s = new Socket(endPt.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
            s.Connect(endPt);
            s.Close();
            isReal = true;
        }
        catch
        {
        }
        return isReal;
    }
