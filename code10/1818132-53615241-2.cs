    using (RSA rsa = RSA.Create())
    {
        rsa.ImportParameters(rsaParameters);
    
        using (X509Certificate2 caSigned = GetCASignedCert(rsa))
        using (X509Certificate2 withKey = caSigned.CopyWithPrivateKey(rsa))
        using (X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
        {
            X509Certificate2 persisted = new X509Certificate2(
                withKey.Export(X509ContentType.Pkcs12, ""),
                "",
                X509KeyStorageFlags.PersistKeySet);
            using (persisted)
            {
                store.Open(OpenFlags.ReadWrite);
                store.Add(persisted);
            }
        }
    }
