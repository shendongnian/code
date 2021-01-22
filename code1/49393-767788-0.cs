    public static IEnumerable<int> IndexesOf(this string haystack, string needle)
    {
        int lastIndex = -1;
        while (true)
        {
            int index = haystack.IndexOf(needle, lastIndex+1);
            if (index == -1)
            {
                yield break;
            }
            yield return index;
            lastIndex = index;
        }
    }
