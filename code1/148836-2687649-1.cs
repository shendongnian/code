    public static string GenerateHash(string pwd, string saltAsBase64)
    {
        byte[] p1 = Convert.FromBase64String(saltAsBase64);
        return GenerateHash(pwd, p1);
    }
    public static string GenerateHash(string pwd, byte[] saltAsByteArray)
    {
        System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
        byte[] p1 = saltAsByteArray;
        byte[] p2 = System.Text.Encoding.Unicode.GetBytes(pwd);
        byte[] data = new byte[p1.Length + p2.Length];
        p1.CopyTo(data, 0);
        p2.CopyTo(data, p1.Length);
        byte[] result = sha.ComputeHash(data);
        string res = Convert.ToBase64String(result);
        return res;
    }
