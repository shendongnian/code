    var serviceCredentials = new ServiceCredentials();
    serviceCredentials.ServiceCertificate.SetCertificate( StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "myserver" );
    serviceCredentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
    serviceCredentials.UserNameAuthentication.CustomUserNamePasswordValidator = this.UserNamePasswordValidator;
    serviceCredentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
    serviceCredentials.ClientCertificate.SetCertificate( StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "SelfSignedWebsiteCertificate" );
    serviceHost.Description.Behaviors.Add( serviceCredentials );
