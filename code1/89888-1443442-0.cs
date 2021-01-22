    bool remoteFileExists(string addressOfFile)
    {
        try
        {
            HttpWebRequest request = WebRequest.Create(addressOfFile) as HttpWebRequest;
            request.Method = "HEAD";
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            var response = request.GetResponse();
            return (response.Headers.Count > 0);  
                // this is a quick, dirty and nasty check, but you
                // can always check the actual returned values here...
        }
        catch(WebException wex)
        {
            return false;
        }
    }
                
