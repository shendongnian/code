    public int GetFileSize(string url)
    {
    	int result = -1;
    
    	System.Net.WebRequest req = System.Net.WebRequest.Create(url);
    	req.Method = "HEAD";
    	using (System.Net.WebResponse resp = req.GetResponse())
    	{
    		if (int.TryParse(resp.Headers.Get("Content-Length"), out int ContentLength))
    		{
    			result = ContentLength;
    		}
    	}
    
    	return result;
    }
