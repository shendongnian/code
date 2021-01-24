    using (var decryptor = crypto.CreateDecryptor())
    {
        using (MemoryStream msDecrypt = new MemoryStream(cipher))
        {
           var sOutputStream = new MemoryStream();
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {               
                csDecrypt.CopyTo(sOutputStream);
            }
            sOutputFilename.Position = 0;
            return sOutputFilename;
        }
    }
