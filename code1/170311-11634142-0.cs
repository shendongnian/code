    public bool TestCredentials(string url, string username, string password)
    {
    	var web = new WebClient();
    	web.Credentials = new NetworkCredential(username,password);
    	
    	try
    	{	
    		web.DownloadData(url);
    		return true;
    	}
    	catch (WebException ex)
    	{
    		var response = (HttpWebResponse)ex.Response;
    		if (response.StatusCode == HttpStatusCode.Unauthorized)
    		{
    			return false;
    		}
    		
    		throw;
    	}	
    }
