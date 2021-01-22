    public static string getMD5(string fullPath)
    {
        MD5 md5 = MD5.Create();
        using (FileStream stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            byte[] hash = md5.ComputeHash(stream);
    	    StringBuilder sb = new StringBuilder();
            for (int j = 0; j < hash.Length; j++)
            {
                sb.Append(hash[j].ToString("X2"));
            }
            return sb.ToString();
        }
    }
