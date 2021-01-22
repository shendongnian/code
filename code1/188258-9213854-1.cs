    if (e.Error.GetType().Name == "WebException")
    {
       WebException we = (WebException)e.Error;
       HttpWebResponse response = (System.Net.HttpWebResponse)we.Response;
       if (response.StatusCode==HttpStatusCode.NotFound)
          System.Diagnostics.Debug.WriteLine("Not found!");
    }
