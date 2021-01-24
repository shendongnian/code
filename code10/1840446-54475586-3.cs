    using (MemoryStream msDecrypt = new MemoryStream())
    {
        using (CryptoStream csDecrypt =
              new CryptoStream(msDecrypt,
                               aesAlg.CreateDecryptor(),
                               CryptoStreamMode.Write))
        {
            csDecrypt.Write(encryptedData, 0, encryptedData.Length);
        }
        return msDecrypt.ToArray();
    }
