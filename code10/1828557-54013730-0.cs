    using (RSA rsa = cert.GetRSAPrivateKey())
    {
        byte[] toSign = Encoding.UTF8.GetBytes(stringToSign);
        myBytes = null;
        try
        {
            myBytes = rsa.SignData(
                toSign, 
                HashAlgorithmName.SHA512, 
                RSASignaturePadding.Pkcs1);
        }
        catch (CryptographicException)
        {
            try
            {
                using (RSA rsaCng = new RSACng())
                {
                    rsaCng.ImportParameters(rsa.ExportParameters(true));
                    myBytes = rsaCng.SignData(
                        toSign,
                        HashAlgorithmName.SHA512, 
                        RSASignaturePadding.Pkcs1);
                }
            }
            catch
            {
            }
            if (myBytes == null)
            {
                // Let the original exception continue
                throw;
            }
        }
    }
