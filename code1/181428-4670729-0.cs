    Stream webStream = null;
    try
    {
        //copy incoming request body to outgoing request
        if (requestStream != null && requestStream.Length>0)
        {
            long length = requestStream.Length;
            webRequest.ContentLength = length;
            webStream = webRequest.GetRequestStream();
            requestStream.CopyTo(webStream);
        }
    }
    finally
    {
        if (null != webStream)
        {
            webStream.Flush();
            webStream.Close();    // might need additional exception handling here
        }
    }
    // No more ProtocolViolationException!
    using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
    {
        ...
    }
