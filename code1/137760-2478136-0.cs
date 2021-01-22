    int MaxBytes = 8912; // set as needed for the max size file you expect to download
    string uri = "http://your.url.here/";
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
    request.Timeout = 5000; // milliseconds, adjust as needed
    request.ReadWriteTimeout = 10000; // milliseconds, adjust as needed
    using (var response = request.GetResponse())
    {
    	using (var responseStream = response.GetResponseStream())
    	{
    		// Process the stream
    		byte[] buf = new byte[1024];
    		string tempString = null;
    		StringBuilder sb = new StringBuilder();
    		int count = 0;
    		do
    		{
    			count = responseStream.Read(buf, 0, buf.Length);
    			if (count != 0)
    			{
    				tempString = Encoding.ASCII.GetString(buf, 0, count);
    				sb.Append(tempString);
    			}
    		}
    		while (count > 0 && sb.Length < MaxBytes);
    
    		responseStream.Close();
    		response.Close();
    
    		return sb.ToString();
    	}
    }
