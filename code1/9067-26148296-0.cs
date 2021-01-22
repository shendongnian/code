    public static string ReplaceInvalidFileNameChars(string s)
    {
        char[] invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();
        foreach (char c in invalidFileNameChars)
            s = s.Replace(c.ToString(), "[" + Array.IndexOf(invalidFileNameChars, c) + "]");
        return s;
    }
