    using (var rijAlg = new AesCng())
    {
        rijAlg.Key = Key;
        rijAlg.IV = IV;
        ICryptoTransform encryptor = rijAlg.CreateEncryptor();
        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                cs.Write(content, 0, content.Length);               
            }
            contentEnc = ms.ToArray();
        }
    }
