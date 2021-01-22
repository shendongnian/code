    private static bool CompareIgnoreAccents(string s1, string s2)
    {
        return string.Compare(
            RemoveAccents(s1), RemoveAccents(s2), StringComparison.InvariantCultureIgnoreCase) == 0;
    }
    
    private static string RemoveAccents(string s)
    {
        Encoding destEncoding = Encoding.GetEncoding("iso-8859-8");
    
        return destEncoding.GetString(
            Encoding.Convert(Encoding.UTF8, destEncoding, Encoding.UTF8.GetBytes(s)));
    }
