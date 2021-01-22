    catch(WebException e)
    {
    if (e.Status == WebExceptionStatus.ProtocolError)
    {
        WebResponse resp = e.Response;
        using(StreamReader sr = new StreamReader(resp.GetResponseStream()))
        {
             Response.Write(sr.ReadToEnd());
        }
    }
    }
