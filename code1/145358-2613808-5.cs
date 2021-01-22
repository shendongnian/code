    WebClient wc = new WebClient();
    wc.Credentials = new NetworkCredential("username", "password");
    string url = "http://foo.com";                  
    try
    {
            using (Stream stream = wc.OpenRead(new Uri(url)))
            {
                    using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                 }
            }
    }
    catch (WebException e)
    {
            //Error handeling
    }
