    public static IEnumerable<string> SplitWithTokens(
        string str,
        string[] separators)
    {
        if (separators == null || separators.Length == 0)
        {
            yield return str;
            yield break;
        }
        int prev = 0;
        for (int i = 0; i < str.Length; i++)
        {
            foreach (var sep in separators)
            {
                if (!string.IsNullOrEmpty(sep))
                {
                    if (((str[i] == sep[0]) && 
                              (sep.Length <= (str.Length - i))) 
                         &&
                        ((sep.Length == 1) || 
                        (string.CompareOrdinal(str, i, sep, 0, sep.Length) == 0)))
                    {
                        if (i - prev != 0)
                            yield return str.Substring(prev, i - prev);
                        yield return sep;
                        i += sep.Length - 1;
                        prev = i + 1;
                        break;
                    }
                }
            }
        }
        if (str.Length - prev > 0)
            yield return str.Substring(prev, str.Length - prev);
    }
 
