    public static bool IsUrlAlive(string aUrl, int aTimeoutSeconds)
    {
        try
        {
            //check the domain first
            if (IsDomainAlive(new Uri(aUrl).Host, aTimeoutSeconds))
            {
                //only now check the url itself
                var request = System.Net.WebRequest.Create(aUrl);
                request.Method = "HEAD";
                request.Timeout = aTimeoutSeconds * 1000;
                var response = (HttpWebResponse)request.GetResponse();
                return response.StatusCode == HttpStatusCode.OK;
            }
        }
        catch
        {
        }
        return false;
    
    }
    private static bool IsDomainAlive(string aDomain, int aTimeoutSeconds)
    {
        try
        {
            using (TcpClient client = new TcpClient())
            {
                var result = client.BeginConnect(aDomain, 80, null, null);
    
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(aTimeoutSeconds));
    
                if (!success)
                {
                    return false;
                }
    
                // we have connected
                client.EndConnect(result);
                return true;
            }
        }
        catch
        {
        }
        return false;
    }
