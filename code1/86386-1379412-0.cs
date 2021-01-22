    static bool GetCheck(string address)
    {
        try
        {
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            request.Method = "GET";
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            var response = request.GetResponse();
            return (response.Headers.Count > 0);
        }
        catch
        {
            return false;
        }
    }
    static bool HeadCheck(string address)
    {
        try
        {
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            request.Method = "HEAD";
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            var response = request.GetResponse();
            return (response.Headers.Count > 0);
        }
        catch
        {
            return false;
        }
    }
