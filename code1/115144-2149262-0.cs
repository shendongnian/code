    try
    {
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Response.Write("has avatar");
    }
    catch (WebException ex)
    {
        if (ex.Status == WebExceptionStatus.ProtocolError) {
            HttpWebResponse resp = (HttpWebResponse) ex.Response;
            if (resp.StatusCode == HttpStatusCode.NotFound)
            {
                Response.Write("No avatar");
            }
            else
                throw;
        }
        else
            throw;
    }
