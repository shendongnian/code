    BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
    basicHttpBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
    basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
    EndpointAddress endpoint = new EndpointAddress("http://myservice");
    var factory = new ChannelFactory<IMyService>(basicHttpBinding, endpoint);
    CredentialCache myCredentialCache = new CredentialCache();
   
    NetworkCredential myCreds = new NetworkCredential("username", "password", "domain");
    myCredentialCache.Add("ContoscoMail", 45, "NTLM", myCreds);
    factory.Credentials.Windows.ClientCredential = 
             myCredentialCache.GetCredential("ContosoMail", 45, "NTLM");
    var client = factory.CreateChannel(); 
    
    // ... use the webservice
