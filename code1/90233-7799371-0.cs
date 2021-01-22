    public static IEnumerable<string> Splice(this string s, int spliceLength)
    {
        if (s == null)
            throw new ArgumentNullException("s");
        if (spliceLength < 1)
            throw new ArgumentOutOfRangeException("spliceLength");
    
        if (s.Length == 0)
            yield break;
        var start = 0;
        for (var end = spliceLength; end < s.Length; end += spliceLength)
        {
            yield return s.Substring(start, spliceLength);
            start = end;
        }
        yield return s.Substring(start);
    }
