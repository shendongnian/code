    public bool IsOnlineTest2()
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
