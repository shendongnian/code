    private static string GenerateHash(string value, string salt)
    {
        byte[] data = System.Text.Encoding.ASCII.GetBytes(salt + value);
        data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
        return Convert.ToBase64String(data);
    }
