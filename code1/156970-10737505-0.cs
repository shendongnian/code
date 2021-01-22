    public static bool SoketConnect(string host, int port)
    {
    	var is_success = false;
    	try
    	{
    		var connsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    		connsock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 200);
    		System.Threading.Thread.Sleep(500);
    		var hip = IPAddress.Parse(host);
    		var ipep = new IPEndPoint(hip, port);
    		connsock.Connect(ipep);
    		if (connsock.Connected)
    		{
    			is_success = true;
    		}
    		connsock.Close();
    	}
    	catch (Exception)
    	{
    		is_success = false;
    	}
    	return is_success;
    }
