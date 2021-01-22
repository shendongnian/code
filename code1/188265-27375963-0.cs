    HttpStatusCode GetHttpStatusCode(System.Exception err)
    {
        if (err is WebException)
        {
            WebException we = (WebException)err;
            if (we.Response is HttpWebResponse)
            {
                HttpWebResponse response = (HttpWebResponse)we.Response;
                return response.StatusCode;
            }
        }
        return 0;
    }
