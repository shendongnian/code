    HttpWebRequest req = (HttpWebRequest) WebRequest.Create("someUrl"));
    req.Credentials = CredentialCache.DefaultCredentials;
    req.Method = "GET";
    using (WebResponse response = req.GetResponse())
    {
        using (StreamReader reader = new StreamReader(response.GetResponseStream(),
                                                      Encoding.Default))
        {
            return reader.ReadToEnd();
        }
    }
