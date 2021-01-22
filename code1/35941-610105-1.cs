    int reti = CryptoApi.CryptGetUserKey(_hprovider, keytype, ref userKey);
    
    if (reti)
    {
        reti =CryptoApi.CryptGetKeyParam(_userKey, KP_CERTIFICATE, ref  pbdata, ref pwddatalen, 0);
    }
    
    if (reti || pwddatalen>0)
    {
        byte[] data = new byte[pwddatalen];
        ret  = CryptoApi.CryptGetKeyParam(_userKey, KP_CERTIFICATE, data, ref pwddatalen, 0);
        if (ret) 
        {
            X509Certificate2 c = new X509Certificate2(data);
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindByThumbprint, c.Thumbprint, validonly);
            store.Close();
    
            if (col.Count != 1) 
            {
                //not found in store - CSP didn't copy it
                c.PrivateKey = PrivateKey(keytype);
                return c;
            }
            else
            {
                return col[0];
            }
        }
    }
    private RSACryptoServiceProvider PrivateKey (KeyType keytype)
    {
        CspParameters csparms = new CspParameters();
        csparms.KeyContainerName = _containerName;
        csparms.ProviderName = _provider;
        csparms.ProviderType = 1;
        csparms.Flags = CspProviderFlags.UseMachineKeyStore | CspProviderFlags.UseExistingKey;
        csparms.KeyNumber = (int)keytype;
    
        return new RSACryptoServiceProvider(csparms);
    }
