    public static string GetRandomAlphaNumeric()
    {
        var chars = 'a'.To('z').Concat('0'.To('9')).ToList();
        return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(8).ToArray());
    }
    public static IEnumerable<char> To(this char start, char end)
    {
        if (end < start)
            throw new ArgumentOutOfRangeException("the end char should not be less than start char", innerException: null);
        return Enumerable.Range(start, end - start + 1).Select(i => (char)i);
    }
