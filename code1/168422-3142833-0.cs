    var params = new CspParameters
    {
         KeyContainerName = "MyEncryptionKey", 
         Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore    
    };
    
    params.CryptoKeySecurity.AddAccessRule(
      new System.Security.AccessControl.CryptoKeyAccessRule(
        new SecurityIdentifier(WellKnownSidType.NetworkServiceSid, null),
        CryptoKeyRights.GenericAll,
        AccessControlType.Allow
      )
    );
    
    var RSA = new RSACryptoServiceProvider(params);
