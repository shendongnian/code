    // Force use of Enhanced RSA and AES Cryptographic Provider to allow use of SHA256.
    var key = cert.PrivateKey as RSACryptoServiceProvider;
    var enhanced = new RSACryptoServiceProvider().CspKeyContainerInfo;
    var parameters = new CspParameters(
        enhanced.ProviderType,
        enhanced.ProviderName,
        key.CspKeyContainerInfo.UniqueKeyContainerName);
    return new RSACryptoServiceProvider(parameters);
