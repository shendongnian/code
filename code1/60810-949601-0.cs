    static public byte[] RSAEncrypt(byte[] data,
        RSAParameters keyInfo, 
        bool doOAEPPadding)
    {
        byte[] encryptedData;
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            //Import the RSA Key information. This only needs
            //toinclude the public key information.
            rsa.ImportParameters(keyInfo);
            //Encrypt the passed byte array and specify OAEP padding.  
            //OAEP padding is only available on Microsoft Windows XP or later.  
            encryptedData = rsa.Encrypt(data, doOAEPPadding);
        }
        return encryptedData;       
    }
