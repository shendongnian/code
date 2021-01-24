    public static byte[] Decrypt(string base64)
    {
        byte[] cipherTextBytes = Convert.FromBase64String(base64);
        byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };
        var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
        using (var memoryStream = new MemoryStream(cipherTextBytes))
        {
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            {
                using (BinaryReader srDecrypt = new BinaryReader(cryptoStream))
                {
                    return srDecrypt.ReadBytes(cipherTextBytes.Length);
                }
            }
        }
    }
