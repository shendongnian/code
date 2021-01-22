    var wr = (HttpWebRequest)HttpWebRequest.Create(messageEndpoint.Location);
    wr.Headers.Add(HttpRequestHeader.Authorization, BuildAuthHeader(messageEndpoint));
    wr.ContentType = messageEndpoint.ContentType;
    wr.Method = CdwHttpMethods.Verbs[messageEndpoint.HttpMethod];
    using (var resp = (HttpWebResponse)req.GetResponse())
    {
    	switch (resp.StatusCode)
    	{
    		case HttpStatusCode.Unauthorized:
    			Assert.Fail("OAuth authorization failed");
    			break;
    		case HttpStatusCode.OK:
    			using (var stream = resp.GetResponseStream())
    			{
    				using (var sr = new StreamReader(stream))
    				{
    					var respString = sr.ReadToEnd();
    				}
    			}
    			break;
    	}
    }
