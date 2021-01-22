    bool remoteFileExists(string addressOfFile)
    {
        try
        {
            HttpWebRequest request = WebRequest.Create(addressOfFile) as HttpWebRequest;
            request.Method = "HEAD";
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            var response = request.GetResponse() as HttpWebResponse;
            return (response.StatusCode == HttpStatusCode.OK);  
        }
        catch(WebException wex)
        {
            return false;
        }
    }
                
