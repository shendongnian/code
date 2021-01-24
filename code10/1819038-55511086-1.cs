    X509Certificate2 publicCertificate = new X509Certificate2(certPath);
    
    var valid = false;
    using (RSA rsa = publicCertificate.GetRSAPublicKey())
    {
        valid = rsa.VerifyData(fileData, signatureData, HashAlgorithmName.SHA512, RSASignaturePadding.Pkcs1);
    }
