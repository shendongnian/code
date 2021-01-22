    var usernameBinding = new BasicHttpBinding( BasicHttpSecurityMode.TransportWithMessageCredential )
    usernameBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
    var certificateBinding = new BasicHttpBinding( BasicHttpSecurityMode.TransportWithMessageCredential )
    certificateBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;
    var serviceHost = new ServiceHost( new MyService() );
    serviceHost.Description.Namespace = "http://schemas.mycompany.com/MyProject";
    serviceHost.AddServiceEndpoint( typeof( T ), usernameBinding, "https://myserver/MyProject/MyService" );
    serviceHost.AddServiceEndpoint( typeof( T ), certificateBinding, "https://myserver/MyProject/Web/MyService" );
