    public static string RemoveAccents(this string s)
    {
        Encoding destEncoding = Encoding.GetEncoding("iso-8859-8");
    
        return destEncoding.GetString(
            Encoding.Convert(Encoding.UTF8, destEncoding, Encoding.UTF8.GetBytes(s)));
    }
