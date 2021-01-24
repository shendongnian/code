    static void Main(string[] args)
    {
        byte[] plainText = Encoding.ASCII.GetBytes("Example String");
        string cipherText;
        using (Aes encryptor = Aes.Create())
        {
            var pdb = new Rfc2898DeriveBytes("Example Key", Encoding.ASCII.GetBytes("Ivan Medvedev"));
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainText, 0, plainText.Length);
                    cs.Close();
                }
                cipherText = Convert.ToBase64String(ms.ToArray());
            }
        }
        Console.WriteLine(cipherText);
    }
