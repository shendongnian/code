    var payload = new Dictionary<string, object>()
    {
        { "sub", "mr.x@contoso.com" },
        { "exp", 1300819380 }
    };
    
    var publicKey=... //Load it from there you need
    
    string token = Jose.JWT.Encode(payload, publicKey, JweAlgorithm.RSA_OAEP, JweEncryption.A256GCM);
