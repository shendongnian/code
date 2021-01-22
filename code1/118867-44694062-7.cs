    public bool IsOnlineTest3()
    {
    	System.Net.WebRequest req = System.Net.WebRequest.Create("https://www.google.com");
    	System.Net.WebResponse resp = default(System.Net.WebResponse);
    	try
        {
    		resp = req.GetResponse();
    		resp.Close();
    		req = null;
    		return true;
    	}
        catch (Exception ex)
        {
    		req = null;
    		return false;
    	}
    }
