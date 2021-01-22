    HttpHeaderInfo result;
    try
    {
        var request = (HttpWebRequest)WebRequest.Create(uri);
        request.Method = "HEAD";
        request.KeepAlive = false;
        request.Timeout = Properties.Settings.Default.WebTimeoutDefault;
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            result = new HttpHeaderInfo();
            result.LastModified = response.LastModified;
            result.ContentType = response.ContentType;
            result.StatusCode = response.StatusCode;
            result.ContentLength = response.ContentLength;
        }
    }
    catch (WebException ex)
    {
        // etc.
    }
