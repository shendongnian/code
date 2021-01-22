    public static void AssignNewKey(){
        const int PROVIDER_RSA_FULL = 1;
        const string CONTAINER_NAME = "KeyContainer";
        CspParameters cspParams;
        cspParams = new CspParameters(PROVIDER_RSA_FULL);
        cspParams.KeyContainerName = CONTAINER_NAME;
        cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
        cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
        rsa = new RSACryptoServiceProvider(cspParams);
        rsa.PersistKeyInCsp = false;
        string publicPrivateKeyXML = rsa.ToXmlString(true);
        string publicOnlyKeyXML = rsa.ToXmlString(false);
        // do stuff with keys...
    }
