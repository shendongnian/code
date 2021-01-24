    private static void DecryptFile(string path, byte[] key)
    {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
            byte[] buffer = new byte[1024];
            byte[] iv = new byte[16];
            long readPos = 0;
            long writePos = 0;
            int bytesRead;
            long readLength = fs.Length - iv.Length;
            // IV is the last 16 bytes
            if (fs.Length < iv.Length)
                throw new IOException("File is too short");
            fs.Position = readLength;
            fs.Read(iv, 0, iv.Length);
            fs.SetLength(readLength);
            using (var aes = new RijndaelManaged()
            {
                Key = key,
                IV = iv,
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CFB,
            })
            using (var cs = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read))
            {
                while (readPos < readLength)
                {
                    fs.Position = readPos;
                    bytesRead = cs.Read(buffer, 0, buffer.Length);
                    readPos = fs.Position;
                    fs.Position = writePos;
                    fs.Write(buffer, 0, bytesRead);
                    writePos = fs.Position;
                }
                // Trim the padding
                fs.SetLength(writePos);
            }
        }
    }
