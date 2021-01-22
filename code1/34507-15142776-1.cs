    public static int GetNumSubstringOccurrences(string text, string search)
    {
        int num = 0;
        int pos = 0;
        if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(search))
        {
            while ((pos = text.IndexOf(search, pos)) > -1)
            {
                num ++;
                pos += search.Length;
            }
        }
        return num;
    }
