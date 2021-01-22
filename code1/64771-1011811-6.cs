    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    public static IEnumerable<string> GetExcelColumns()
    {
        return GetExcelColumns(Alphabet);
    }
    public static IEnumerable<string> GetExcelColumns(string alphabet)
    {
        foreach(char c in alphabet)
        {
            yield return c.ToString();
        }
        char[] chars = new char[2];
        foreach(char high in alphabet)
        {
            chars[0] = high;
            foreach(char low in alphabet)
            {
                chars[1] = low;
                yield return new string(chars);
            }
        }
    }
