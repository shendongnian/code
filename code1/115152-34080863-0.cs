    try
    {
        var request = WebRequest.Create(uri);
        using (var response = request.GetResponse())
        using (var responseStream = response.GetResponseStream())
        {
            // Process the stream
        }
    }
    catch(WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
    {
        // handle 404 exceptions
    }
    catch (WebException ex)
    {
        // handle other web exceptions
    }
