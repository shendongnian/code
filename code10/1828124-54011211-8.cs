    using (RSA rsa = RSA.Create())
    {
        rsa.ImportRSAPrivateKey(PemToBer(pemPrivateKey, RsaPrivateKey), out _);
        ...
    }
    using (RSA rsa = RSA.Create())
    {
        rsa.ImportSubjectPublicKeyInfo(PemToBer(pemPublicKey, SubjectPublicKeyInfo), out _);
        ...
    }
