    var rsa = certificate.PrivateKey as RSACryptoServiceProvider;
    if (rsa != null)
    {
        // Modifying the CryptoKeySecurity of a new CspParameters and then instantiating
        // a new RSACryptoServiceProvider seems to be the trick to persist the access rule.
        // cf. http://blogs.msdn.com/b/cagatay/archive/2009/02/08/removing-acls-from-csp-key-containers.aspx
        var cspParams = new CspParameters(rsa.CspKeyContainerInfo.ProviderType, rsa.CspKeyContainerInfo.ProviderName, rsa.CspKeyContainerInfo.KeyContainerName)
        {
            Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore,
            CryptoKeySecurity = rsa.CspKeyContainerInfo.CryptoKeySecurity
        };
    
        cspParams.CryptoKeySecurity.AddAccessRule(new CryptoKeyAccessRule(sid, CryptoKeyRights.GenericRead, AccessControlType.Allow));
    
        using (var rsa2 = new RSACryptoServiceProvider(cspParams))
        {
            // Only created to persist the rule change in the CryptoKeySecurity
        }
    }
