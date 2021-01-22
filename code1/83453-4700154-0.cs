    try
    {
        wResp = (HttpWebResponse)wReq.GetResponse();
        wRespStatusCode = wResp.StatusCode;
    }
    catch (WebException we)
    {
        wRespStatusCode = (HttpWebResponse)we.Response).StatusCode;
    }
