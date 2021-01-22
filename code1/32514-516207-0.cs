    try 
    {
        // Do WebRequest
    }
    catch (WebException ex) 
    {
        if (ex.Status == WebExceptionStatus.ProtocolError) 
        {
            HttpWebResponse response = ex.Response as HttpWebResponse;
            if (response != null)
            {
                // Process response
            }
        }
    }
