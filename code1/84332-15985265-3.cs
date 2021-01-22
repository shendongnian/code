    public static string GetRandomAlphaNumeric()
    {
        var chars = 'a'.To('z').Concat('0'.To('9')).Cast<char>().ToArray();
        return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(8).ToArray());
    }
    public static IEnumerable<int> To(this char start, char end)
    {
        return Enumerable.Range(start, end - start + 1);
    }
