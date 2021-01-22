    public bool IsOnlineTest1()
    {
    	try
        {
    		IPHostEntry dummy = Dns.GetHostEntry("https://www.google.com");
    		return true;
    	}
        catch (SocketException ex)
        {
    		return false;
    	}
    }
