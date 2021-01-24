    public string GetNewText(string url)
    {
        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        request.Credentials = CredentialCache.DefaultCredentials;
        using (var response = request.GetResponse())
        {
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd().ToLower();
            }
        }
    }
