    public static IEnumerable<string> SplitAndKeep(this string s, char[] delims)
    {
        int start = 0, index;
        while ((index = s.IndexOfAny(delims, start)) != -1)
        {
            if(index-start > 0)
                yield return s.Substring(start, index - start);
            yield return s.Substring(index, 1);
            start = index + 1;
        }
        if (start < s.Length)
        {
            yield return s.Substring(start);
        }
    }
