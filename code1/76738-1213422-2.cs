    public static string Md5HashString(string input)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(input);
        byte[] hash;
        using (MD5 md5 = MD5.Create())
        {
            hash = md5.ComputeHash(bytes);
        )
        return Convert.ToBase64String(hash);
    }
