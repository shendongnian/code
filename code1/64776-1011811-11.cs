    public static IEnumerable<string> GetExcelColumns()
    {
        for (char c = 'a'; c <= 'z'; c++)
        {
            yield return c.ToString();
        }
        char[] chars = new char[2];
        for (char high = 'a'; high <= 'z'; high++)
        {
            chars[0] = high;
            for (char low = 'a'; low <= 'z'; low++)
            {
                chars[1] = low;
                yield return new string(chars);
            }
        }
    }
