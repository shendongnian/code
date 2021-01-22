    public static byte[] Zip(string str)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(str);    
        using (var msi = new MemoryStream(bytes))
        using (var mso = new MemoryStream())
        {
            using (var gs = new GZipStream(mso, CompressionMode.Compress))
            {                        
                CopyTo(msi, gs);
            }    
            return mso.ToArray();
        }
    }
    public static string Unzip(byte[] bytes)
    {
        using (var msi = new MemoryStream(bytes))
        using (var mso = new MemoryStream())
        {
            using (var gs = new GZipStream(msi, CompressionMode.Decompress))
            {                     
                CopyTo(gs, mso);
            }    
            return System.Text.Encoding.UTF8.GetString(mso.ToArray());
        }
    }
    public static byte[] Zip(string str)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(str);    
        using (var msi = new MemoryStream(bytes))
        using (var mso = new MemoryStream())
        {
            using (var gs = new GZipStream(mso, CompressionMode.Compress))
            {
                CopyTo(msi, gs);
            }    
            return mso.ToArray();
        }
    }
