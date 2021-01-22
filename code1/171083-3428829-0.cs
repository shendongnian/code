    public void ProcessRequest(HttpContext context)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create([NEW_URL]);
        request.Timeout = 1000 * 60 * 60;
        request.Method = context.Request.HttpMethod;
        if (request.Method.ToUpper() == "POST")
        {
            Stream sourceInputStream = context.Request.InputStream;
            Stream targetOutputStream = request.GetRequestStream();
            sourceInputStream.CopyTo(targetOutputStream);                
        }
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        context.Response.ContentType = request.ContentType;
        using (response)
        {
            Stream targetInputStream = response.GetResponseStream();
            Stream sourceOutputStream = context.Response.OutputStream;
            targetInputStream.CopyTo(sourceOutputStream);                
        }
    }
