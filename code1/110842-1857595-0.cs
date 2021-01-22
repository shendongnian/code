    HttpWebResponse response;
    try
    {
        response = request.GetResponse() as HttpWebResponse;
    }
    catch (WebException ex)
    {
        response = ex.Response as HttpWebResponse;
    }
