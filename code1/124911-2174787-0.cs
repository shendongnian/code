    private static string SendRequest(string url, string postdata)
    {
        if (String.IsNullOrEmpty(postdata))
            return null;
        HttpWebRequest rqst = (HttpWebRequest)HttpWebRequest.Create(url);
        // No proxy details are required in the code.
        rqst.Proxy = GlobalProxySelection.GetEmptyWebProxy();
        rqst.Method = "POST";
        rqst.ContentType = "application/x-www-form-urlencoded";
        // In order to solve the problem with the proxy not recognising the user
        // agent, a default value is provided here.
        rqst.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
        byte[] byteData = Encoding.UTF8.GetBytes(postdata);
        rqst.ContentLength = byteData.Length;
        using (Stream postStream = rqst.GetRequestStream())
        {
            postStream.Write(byteData, 0, byteData.Length);
            postStream.Close();
        }
        StreamReader rsps = new StreamReader(rqst.GetResponse().GetResponseStream());
        string strRsps = rsps.ReadToEnd();
        return strRsps;
    }
