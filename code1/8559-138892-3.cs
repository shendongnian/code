    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.example.com");
    request.Credentials = System.Net.CredentialCache.DefaultCredentials;
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    if (response.StatusCode == HttpStatusCode.OK)
    {
        using( StreamReader sr = new StreamReader( response.GetResponseStream() )
        {
            List<Uri> links = FetchLinksFromSource( sr.ReadToEnd() );
        }
    }
