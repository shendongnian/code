            BasicHttpBinding basicHttpbinding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            basicHttpbinding.Name = "BasicHttpBinding_YourName";
            basicHttpbinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            basicHttpbinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            EndpointAddress endpointAddress = new EndpointAddress("http://<Your machine>/Service1/Service1.svc");
            Service1Client proxyClient = new Service1Client(basicHttpbinding,endpointAddress);
   
