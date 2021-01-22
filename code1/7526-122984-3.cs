    public long GetFileSize(string url)
    {
    	long result = -1;
    
    	System.Net.WebRequest req = System.Net.WebRequest.Create(url);
    	req.Method = "HEAD";
    	using (System.Net.WebResponse resp = req.GetResponse())
    	{
    		if (long.TryParse(resp.Headers.Get("Content-Length"), out long ContentLength))
    		{
    			result = ContentLength;
    		}
    	}
    
    	return result;
    }
