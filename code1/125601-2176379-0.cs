    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        using (Stream responseStream = response.GetResponseStream())
        {
            using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
            {
               // Put in code to check response status. You'll probably get a 404 when not found.
            }
        }
    }
