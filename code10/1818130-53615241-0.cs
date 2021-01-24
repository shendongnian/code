    using (RSA rsa = RSA.Create())
    {
        rsa.ImportParameters(rsaParameters);
        using (X509Certificate2 caSigned = GetCASignedCert(rsa))
        using (X509Certificate2 withKey = caSigned.CopyWithPrivateKey(rsa))
        {
            File.WriteAllBytes("some.pfx", withKey.Export(X509ContentType.Pkcs12, "and a password"));
        }
    }
