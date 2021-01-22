    private static bool UrlExists(string url)
    {
    	try
    	{
    		new System.Net.WebClient().DownloadData(url);
    		return true;
    	}
    	catch (System.Net.WebException e)
    	{
    		if (((System.Net.HttpWebResponse)e.Response).StatusCode == System.Net.HttpStatusCode.NotFound)
    			return false;
    		else
    			throw;
    	}
    }
