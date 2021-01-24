    public bool ConnectGoogle()
    {
    	try
    	{
    		HttpURLConnection urlc = (HttpURLConnection)(new URL("http://www.google.com").OpenConnection());
    		urlc.SetRequestProperty("User-Agent", "Test");
    		urlc.SetRequestProperty("Connection", "close");
    		urlc.ConnectTimeout = 10000;
    		urlc.Connect();
    		return (urlc.ResponseCode == HttpStatus.Accepted);
    	}
    	catch (Exception ex)
    	{
    		//Log(ex.Message);
    		return false;
    	}
    }
