    public static IEnumerable<int> ExtractNumbers(
        string s
        char separator
        Func<int, bool> predicate)
    {
        if (s == null)
            throw new ArgumentNullException(name(s));
        foreach (var n in s.Split(separator))
        {
             if (int.TryParse(out var number)
             {
                 if (predicate(number))
                     yield return number;
             }
        }
    }
