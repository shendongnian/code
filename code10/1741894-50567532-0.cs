    public static string Hash(bool caseInsensitive, params string[] strs)
    {
        using (var sha256 = SHA256.Create())
        {
            for (int i = 0; i < strs.Length; i++)
            {
                string str = caseInsensitive ? strs[i].ToUpperInvariant() : strs[i];
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                byte[] length = BitConverter.GetBytes(bytes.Length);
                sha256.TransformBlock(length, 0, length.Length, length, 0);
                sha256.TransformBlock(bytes, 0, bytes.Length, bytes, 0);
            }
            sha256.TransformFinalBlock(new byte[0], 0, 0);
            var hash = sha256.Hash;
            return Convert.ToBase64String(hash);
        }
    }
