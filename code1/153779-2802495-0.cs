    using System.Security.Cryptography;
    
    // ....
    
    byte[] SignData(byte[] toSign)
    {
        RSACryptoServiceProvider rsaCert =
                GetCertificateWithPrivateKeyFromSomewhere(); // this method is yours
        return rsaCert.SignData(toSign, new SHA1CryptoServiceProvider());
    }
    
    bool VerifyData(byte[] toVerify, byte[] signature)
    {
        RSACryptoServiceProvider rsaCert =
                GetCertificateWithPublicKeyFromSomewhere(); // this method is yours
        return rsaCert.VerifyData(toVerify, new SHA1CryptoServiceProvider(), signature);
    }
