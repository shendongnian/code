    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
 
    if (response.StatusCode == HttpStatusCode.OK)
    {
        using (Stream stream = response.GetResponseStream())
        {
            // Do work
            ...
        }
    }
    else
    {
        // Error
    }
