    public static string GetRandomFileName(string extension)
    {
        StringBuffer sb = new StringBuffer(Guid.NewGuid().ToString());
        if (!string.IsNullOrEmpty(extensions))
        {
            sb.Append(".");
            sb.Append(extension);
        }
        
        return sb.ToString();
    }
