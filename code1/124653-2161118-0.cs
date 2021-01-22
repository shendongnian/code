    private Byte[] CryptoKey
    {
        get { return new Byte[] { 0x0E, 0x41, 0x6A, 0x29, 0x94, 0x12, 0xEB, 0x63 }; }
    }
    public Byte[] Encrypt(Byte[] bytes)
    {
        using (var crypto = new DESCryptoServiceProvider())
        {
            var key = CryptoKey;
            using (var encryptor = crypto.CreateEncryptor(key, key))
            {
                return encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
            }
        }
    }
    public Byte[] Decrypt(Byte[] bytes)
    {
        using (var crypto = new DESCryptoServiceProvider())
        {
            var key = CryptoKey;
            using (var decryptor = crypto.CreateDecryptor(key, key))
            {
                return decryptor.TransformFinalBlock(bytes, 0, bytes.Length);
            }
        }
    }
