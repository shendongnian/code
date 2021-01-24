    public static string[] Transform(string str)
    {
        var strs = new string [str.Length];
        var sb = str.ToCharArray();
    
        char oldCh;
        for (int i = 0; i < str.Length; i++)
        {
            oldCh = sb[i];
            sb[i] = char.ToUpper(sb[i]);
            strs[i] = new string (sb);
            sb[i] = oldCh;
        }
        return strs;
    }
