    using (var decryptor = crypto.CreateDecryptor())
    {
        using (MemoryStream msDecrypt = new MemoryStream(cipher))
        {
           var outputStream = new MemoryStream();
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {               
                csDecrypt.CopyTo(outputStream );
            }
            outputStream .Position = 0;
            return outputStream ;
        }
    }
