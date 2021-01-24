     ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
                ServiceReference2.Service1Client client = new ServiceReference2.Service1Client();
                client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
     new X509ServiceCertificateAuthentication()
     {
         CertificateValidationMode = X509CertificateValidationMode.None,
         RevocationMode = X509RevocationMode.NoCheck
     };
