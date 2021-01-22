    try
    {
        // try to download file here
    }
    catch (WebException ex)
    {
        if (ex.Status == WebExceptionStatus.ProtocolError)
        {
            if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
            {
                // handle the 404 here
            }
        }
        else if (ex.Status == WebExceptionStatus.NameResolutionFailure)
        {
            // handle name resolution failure
        }
    }
