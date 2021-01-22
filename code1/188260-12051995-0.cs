    if (e.Status == WebExceptionStatus.ProtocolError)
    {
       HttpWebResponse response = (HttpWebResponse)ex.Response;             
       if (response.StatusCode == HttpStatusCode.NotFound)
          System.Diagnostics.Debug.WriteLine("Not found!");
    }
