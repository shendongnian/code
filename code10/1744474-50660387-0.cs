    X509Certificate2 publicPrivate;
    using (ECDsa clientPrivateKey = ECDsa.Create())
    {
        var request = new CertificateRequest(
            "CN=Et. Cetera",
            clientPrivateKey,
            HashAlgorithmName.SHA256);
        // Assuming this isn't another CA cert:
        request.CertificateExtensions.Add(
            new X509BasicConstraintsExtension(false, false, 0, false));
        // other CertificateExtensions as you desire.
        // Assign, or derive, a serial number.
        // RFC 3280 recommends that it have no more than 20 bytes encoded.
        // 12 random bytes seems long enough.
        byte[] serial = new byte[12];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(serial);
        }
        DateTimeOffset notBefore = DateTimeOffset.UtcNow;
        DateTimeOffset notAfter = notBefore.AddMonths(15);
        using (X509Certificate2 publicOnly = request.Create(
            msRootCert,
            notBefore,
            notAfter,
            serial))
        {
            publicPrivate = publicOnly.CopyWithPrivateKey(clientPrivateKey);
        }
    }
    // The original key object was disposed,
    // but publicPrivate.GetECDsaPrivateKey() still works.
