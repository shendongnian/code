    byte[] derivedKey;
    using (var privateKey = (ECDsaCng)certificate.GetECDsaPrivateKey())
    using (var publicKey = (ECDsaCng)certificate.GetECDsaPublicKey())
    {
        var publicParams = publicKey.ExportParameters(false);
        using (var publicCng = ECDiffieHellmanCng.Create(publicParams))
        using (var diffieHellman = new ECDiffieHellmanCng(privateKey.Key))
        {
            derivedKey = diffieHellman.DeriveKeyMaterial(publicCng.PublicKey);
        }
    }
    return derivedKey;
