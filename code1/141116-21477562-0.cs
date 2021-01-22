    WebRequest webRequest = WebRequest.Create(sURL);
    webRequest.Method = "POST";
    webRequest.ContentLength = byteDataGZ.Length;
    webRequest.Proxy = null;
    using (var requestStream = webRequest.GetRequestStream())
    {
        requestStream.WriteTimeout = 500;
        requestStream.Write(byteDataGZ, 0, byteDataGZ.Length);
        requestStream.Close();
    }
    // Get the response so that we don't leave this request hanging around
    WebResponse response = webRequest.GetResponse();
    response.Close();
