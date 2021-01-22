    myClient.ClientCredentials.ClientCertificate.SetCertificate(
        StoreLocation.LocalMachine,
        StoreName.My,
        X509FindType.FindByThumbprint,
        "1234abcd");
    myClient.ClientCredentials.ServiceCertificate.SetDefaultCertificate(
        StoreLocation.LocalMachine,
        StoreName.My,
        X509FindType.FindByThumbprint,
        "5678efgh");
    myClient.ClientCredentials.ServiceCertificate.Authentication.TrustedStoreLocation = StoreLocation.LocalMachine;
    myClient.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
