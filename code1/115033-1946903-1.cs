    public static string UniqueChars(this string original)
    {
        string[] chars = original
            .ToCharArray()
            .Distinct()
            .Select(c => c.ToString())
            .ToArray();
        return string.Join(string.Empty, chars);
    }
