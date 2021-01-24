    using (var aes = new AesManaged())
    {
        byte[] key = Encoding.ASCII.GetBytes("YELLOW SUBMARINE");
        aes.Key = key;
        aes.Mode = CipherMode.ECB;
        string b64 = File.ReadAllText("7.txt");
        byte[] bytes = Convert.FromBase64String(b64);
        using (var decryptor = aes.CreateDecryptor())
        {
            byte[] result = decryptor.TransformFinalBlock(bytes, 0, bytes.Length);
            string text = Encoding.ASCII.GetString(result);
        }
    }
