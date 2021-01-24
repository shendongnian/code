    private static byte[] salt = new byte[] { 34, 134, 145, 12, 7, 6, 243, 63, 43, 54, 75, 65, 53, 2, 34, 54, 45, 67, 64, 64, 32, 213 };
    private static byte[] vector = Encoding.ASCII.GetBytes("16806642kbM7c5!$");
    private static string cleartext = "8212093345";
    static void Main(string[] args)
    {
        var kdf = new Rfc2898DeriveBytes("KJH#$@kds32@!kjhdkftt", salt);
        using (var aes = new RijndaelManaged())
        {
            aes.Key = kdf.GetBytes(aes.KeySize / 8);
            aes.IV = vector;
            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    // don't use StreamWriter, it just makes things more complicated
                    var bytes = Encoding.ASCII.GetBytes(cleartext);
                    cs.Write(bytes, 0, bytes.Length);
                }
                Console.WriteLine(Convert.ToBase64String(ms.ToArray()));
                // outputs: oYIvjoubW7D4Ds+SrAh49A==
            }
        }
    }
