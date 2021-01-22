    public static string ProperCase(string text)
    {
        return text.Aggregate(
            string.Empty,
            (acc, c) => Char.ToLower(c) != c ? acc + " " + c.ToString() : acc + c.ToString())
            .Trim();
    }
