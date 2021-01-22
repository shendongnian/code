    EndpointAddress endpoint =
      new EndpointAddress(new Uri("http://SharePointserver/_vti_bin/InvoiceServices.svc"));
    BasicHttpBinding httpBinding = new BasicHttpBinding();
    httpBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
    httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
    InvoiceServicesClient myClient = new InvoiceServicesClient(httpBinding, endpoint);
    myClient.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation; 
    (call service)
