    private readonly RSA _rsa;
    public TokenManager() {
        // import instead of creating new, if necessary
        _rsa = new RSACryptoServiceProvider(2048);            
    }
    // ...
    SigningCredentials = new SigningCredentials(
        new RsaSecurityKey(_rsa), 
        SecurityAlgorithms.RsaSha256Signature)
