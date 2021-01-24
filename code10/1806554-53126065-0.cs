    byte[] encryptedData;
    rijCrypto.Padding = System.Security.Cryptography.PaddingMode.ISO10126;
    rijCrypto.KeySize = 256;
    using (var input = new MemoryStream(Encoding.Unicode.GetBytes(tempData)))
    using (var output = new MemoryStream())
    {
        var encryptor = rijCrypto.CreateEncryptor();
        using (var cryptStream = new CryptoStream(output, encryptor, CryptoStreamMode.Write))
        {
            var buffer = new byte[1024];
            var read = input.Read(buffer, 0, buffer.Length);
            while (read > 0)
            {
                cryptStream.Write(buffer, 0, read);
                read = input.Read(buffer, 0, buffer.Length);
            }
            cryptStream.FlushFinalBlock();
            encryptedData = output.ToArray();
        }
    }
