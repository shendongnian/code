    private TestServiceClient GetTestServiceClient()
    {
        var address = new EndpointAddress("https://known.to.be/working/service/endpoint");
        var binding = new BasicHttpsBinding()
        {
            Name = "basic_SSL_Cert",
    
            // ... other properties that work fine in full .Net Framework 
                
            //Security = new BasicHttpsSecurity()
            //{
            //    Mode = BasicHttpsSecurityMode.Transport,
            //    Transport = new HttpTransportSecurity()
            //    {
            //        // ... so I can't set this :(
            //        ClientCredentialType = HttpClientCredentialType.Certificate,
            //        ProxyCredentialType = HttpProxyCredentialType.None
            //    }
            //}
        };
    
        // Just set it... doh!
        binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
    
        var client = new TestServiceCLient(binding, address);
    
        client.ClientCredentials.ClientCertificate.SetCertificate(
            StoreLocation.LocalMachine, 
            StoreName.My, 
            X509FindType.FindBySubjectDistinguishedName, 
            "I can find the cert no problem."
        );
    
        return client;
    }
