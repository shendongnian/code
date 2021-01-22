    try
    {
        var request = WebRequest.Create(uri);
        using (var response = request.GetResponse())
        {
            using (var responseStream = response.GetResponseStream())
            {
                // Process the stream
            }
        }
    }
    catch (WebException ex)
    {
        if (ex.Status == WebExceptionStatus.ProtocolError &&
            ex.Response != null)
        {
            var resp = (HttpWebResponse) ex.Response;
            if (resp.StatusCode == HttpStatusCode.NotFound)
            {
                // Do something
            }
        }
    }
