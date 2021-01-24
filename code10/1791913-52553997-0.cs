    protected override WebRequest GetWebRequest(Uri _uri)
    {
    
    	HttpWebRequest _webRequest = base.GetWebRequest(_uri) as HttpWebRequest;
    
    	if (_webRequest != null)
    	{
    		// no buffer
    		_webRequest.AllowWriteStreamBuffering = false;
    		// if data size overhanded in constructur(necessary with AllowWriteStreamBuffering ==  false)
    		if (this.ContentLength > 0)
    			_webRequest.ContentLength = this.ContentLength;
    		// if NO data size overhanded in constructur(necessary with AllowWriteStreamBuffering ==  false)
    		else
    			_webRequest.SendChunked = true;
    		// if timeout overhanded in constructur
    		if (this.TimeOut > 0)
    			_webRequest.Timeout = this.TimeOut * 1000;
    
    		return (_webRequest);
    	}
    	else
    		return (null);
    }
