    private async Task<HttpResponseMessage> DoRequest(string pRequest, string pBody, ClientMethod pClientMethod)
    {
        try
        {
            HttpClientHandler _httpclienthndlr = new HttpClientHandler();                
               
    //update for your auth                 
            if (UseDefaultCredentials) _httpclienthndlr.Credentials = CredentialCache.DefaultCredentials;
            else if (TFSDomain == "") _httpclienthndlr.Credentials = new NetworkCredential(TFSUserName, TFSPassword);
            else _httpclienthndlr.Credentials = new NetworkCredential(TFSUserName, TFSPassword, TFSDomain);
            using (HttpClient _httpClient = new HttpClient(_httpclienthndlr))
            {
                switch (pClientMethod)
                {
	    			case ClientMethod.GET:
		    			return await _httpClient.GetAsync(pRequest);
			    	case ClientMethod.POST:
				    	return await _httpClient.PostAsync(pRequest, new StringContent(pBody, Encoding.UTF8, "application/json"));
                    case ClientMethod.PATCH:
                        var _request = new HttpRequestMessage(new HttpMethod("PATCH"), pRequest);
                        _request.Content = new StringContent(pBody, Encoding.UTF8, "application/json-patch+json");                            
                        return await _httpClient.SendAsync(_request);
                    default:
                        return null;
                }
                                        
            }
        }
        catch (Exception _ex)
        {
            throw new Exception("Http Request Error", _ex);
        }
    }
