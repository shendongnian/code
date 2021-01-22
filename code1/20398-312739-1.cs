    public static IEnumerable<String> GetWords(Int32 length)
    {
        if (length <= 0)
            yield break;
        for (Char c = 'A'; c <= 'Z'; c++)
        {
            if (length > 1)
            {
                foreach (String restWord in GetWords(length - 1))
                    yield return c + restWord;
            }
            else
                yield return "" + c;
        }
    }
