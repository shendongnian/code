    private string Encrypt(string input)
    {
      return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(input)));
    }
    private byte[] Encrypt(byte[] input)
    {
      PasswordDeriveBytes pdb = new PasswordDeriveBytes("hjiweykaksd", new byte[] { 0x43, 0x87, 0x23, 0x72, 0x45, 0x56, 0x68, 0x14, 0x62, 0x84 });
      MemoryStream ms = new MemoryStream();
      Aes aes = new AesManaged();
      aes.Key = pdb.GetBytes(aes.KeySize / 8);
      aes.IV = pdb.GetBytes(aes.BlockSize / 8);
      CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
      cs.Write(input, 0, input.Length);
      cs.Close();
      return ms.ToArray();
    }
    private string Decrypt(string input)
    {
      return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(input)));
    }
    private byte[] Decrypt(byte[] input)
    {
      PasswordDeriveBytes pdb = new PasswordDeriveBytes("hjiweykaksd", new byte[] { 0x43, 0x87, 0x23, 0x72, 0x45, 0x56, 0x68, 0x14, 0x62, 0x84 });
      MemoryStream ms = new MemoryStream();
      Aes aes = new AesManaged();
      aes.Key = pdb.GetBytes(aes.KeySize / 8);
      aes.IV = pdb.GetBytes(aes.BlockSize / 8);
      CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
      cs.Write(input, 0, input.Length);
      cs.Close();
      return ms.ToArray();
    }
