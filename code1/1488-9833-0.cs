    public static string[] RemoveDuplicates(string[] s)
    {
        HashSet<string> set = new HashSet<string>(s);
        string[] result = new string[set.Count];
        set.CopyTo(result);
        return result;
    }
