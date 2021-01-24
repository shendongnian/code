    byte[] response = Encoding.ASCII.GetBytes(output);
    var request = (HttpWebRequest)WebRequest.Create(poom.HOOK_URL);
    request.ContentType = "application/x-www-form-urlencoded";
    request.Method = "POST";
    try
    {
        request.GetRequestStream().Write(response, 0, response.Length);
    }
    catch (Exception ex)
    {
        LogHelpers.Write(log, ex);
    }
    WebResponse webresponse = null;
    try
    {
        webresponse = request.GetResponse();
    }
    catch (Exception ex)
    {
        LogHelpers.Write(log, ex);
    }
