    try
    {
        // TODO: Make request.
    }
    catch (WebException ex)
    {
        if (ex.Status == WebExceptionStatus.ProtocolError) {
            HttpWebResponse resp = ex.Response as HttpWebResponse;
            if (resp != null && resp.StatusCode == HttpStatusCode.NotFound)
            {
                // TODO: Handle 404 error.
            }
            else
                throw;
        }
        else
            throw;
    }
