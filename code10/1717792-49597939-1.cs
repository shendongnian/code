    public static IEnumerable<int> ExtractOddNumbers(
        string s
        char separator)
    {
        if (s == null)
            throw new ArgumentNullException(name(s));
        foreach (var n in s.Split(separator))
        {
             if (int.TryParse(out var number)
             {
                 if (number % 2 != 0)
                     yield return number;
             }
        }
    }
