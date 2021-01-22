    WebRequest req = WebRequest.Create(tokenUri);
    req.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
    req.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
    WebResponse resp = req.GetResponse();
    StreamReader reader = new StreamReader(resp.GetResponseStream());
    var token = reader.ReadToEnd().Trim();
