    public static string Md5HashString(string input)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(input);
        byte[] hash = MD5.Create().ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
