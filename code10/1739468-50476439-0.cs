    using (RSA rsa = RSA.Create(2048))
    {
        CertificateRequest request = new CertificateRequest(
            "CN=Your Name Here",
            rsa,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1);
        SubjectAlternativeNameBuilder builder = new SubjectAlternativeNameBuilder();
        builder.AddDnsName("your.name.here");
        builder.AddDnsName("your.other.name.here");
        request.CertificateExtensions.Add(builder.Build());
        // Any other extensions you're supposed to request, like not being a CA.
        request.CertificateExtensions.Add(
            new X509BasicConstraintsExtension(false, false, 0, false));
        // TLS Server?
        request.CertificateExtensions.Add(
            new X509EnhancedKeyUsageExtension(
                new OidCollection
                {
                    new Oid("1.3.6.1.5.5.7.3.1")
                },
                false));
        byte[] derEncodedRequest = request.CreateSigningRequest();
        X509Certificate2 responseWithPrivateKey;
        using (X509Certificate2 response = SendRequestToServerAndGetResponse(derEncodedRequest))
        {
            responseWithPrivateKey = response.CopyWithPrivateKey(rsa);
        }
        // Use it, save it to a PFX, whatever.
        // At this point, nothing has touched the hard drive.
    }
