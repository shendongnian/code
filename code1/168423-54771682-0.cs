    //Read the current settings
    CspParameters csp = new CspParameters(PROVIDER_RSA_FULL)
    {
        KeyContainerName = container,
        Flags = CspProviderFlags.NoPrompt | CspProviderFlags.UseMachineKeyStore | CspProviderFlags.UseExistingKey
    };
    //Retrieve Current Settings
    using (var rsa = new RSACryptoServiceProvider(csp))
    {
        var ci = rsa.CspKeyContainerInfo;
        //Create new settings and copy values over
        CspParameters csp2 = new CspParameters(PROVIDER_RSA_FULL)
        {
            KeyContainerName = container,
            Flags = CspProviderFlags.NoPrompt | CspProviderFlags.UseMachineKeyStore | CspProviderFlags.UseExistingKey,
            CryptoKeySecurity = ci.CryptoKeySecurity,
            ProviderName = ci.ProviderName,
            ProviderType = ci.ProviderType
        };
        //Add Permissions
        csp2.CryptoKeySecurity.AddAccessRule(new CryptoKeyAccessRule(securityIdentifier, CryptoKeyRights.FullControl, AccessControlType.Allow));
        //Save settings
        using (var rsa2 = new RSACryptoServiceProvider(csp2))
        {
        }
    }
