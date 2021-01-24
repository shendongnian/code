    // By default WCF will check that the DnsName of the certificate matchs the DNS name of the endpoint we need to override this.
    // We did want want to require an appliction to use the same cert that is for SSL as for message encryption
    EndpointIdentity endpointIdentity = null;
    if (endpoint.EncryptionCertificate != null)
        endpointIdentity = EndpointIdentity.CreateDnsIdentity(endpoint.EncryptionCertificate.GetCertificate().GetNameInfo(X509NameType.DnsName, false));
    else
        endpointIdentity = EndpointIdentity.CreateDnsIdentity(endpoint.Address);
    AddressHeader[] header = null;
    using (var client = new portTypeClient(binding, new EndpointAddress(new Uri(address), endpointIdentity, header)))
    {
        if (/* Encryption is needed */)
        {
            var certificate = LoadX509Certificate();
            client.ClientCredentials.ServiceCertificate.DefaultCertificate = certificate;
        }
    }
