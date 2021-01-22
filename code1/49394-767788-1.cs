    public static IEnumerable<int> IndexesOf(this string haystack, string needle)
    {
        int lastIndex = 0;
        while (true)
        {
            int index = haystack.IndexOf(needle, lastIndex);
            if (index == -1)
            {
                yield break;
            }
            yield return index;
            lastIndex = index + needle.Length;
        }
    }
