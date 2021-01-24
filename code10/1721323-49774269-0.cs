    private static string  WeirdArrangement (string input)
    {
        //string input = "aabbcc[aczç_eyvur]";
        string validChars = "abc";
        string pattern = "abc";     // Must be a composition of  all valid char
        var invalidChars = input.Where(c => !validChars.Contains(c));
        var validOccurences = input.Where(c => validChars.Contains(c))
                                    .GroupBy(c => c)
                                    .Select(c => new { Char = c.Key, Count = c.Count() });
        var minPattern = validOccurences.Min(o => o.Count);
        // Build time
        StringBuilder builder = new StringBuilder();
            //new StringBuilder(pattern.Length * minPattern + invalidChars.Count() + leftoverCount);
        // X time partern
        for (int i = 0; i < minPattern; i++) builder.Append(pattern);
        //Rest of the validOccurences
        foreach (var charOccurency in validOccurences)
        {
            for (int i = minPattern; i < charOccurency.Count; i++) builder.Append(charOccurency.Char);
        }
        //Invalid char
        foreach (var invalidChar in invalidChars)
        {
            builder.Append(invalidChar);
        };
        return builder.ToString();
    }
