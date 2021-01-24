    public static bool ContainsOnlySymbols(string inputString)
    {
        // Go through the characters of the input string checking for symbols
        return !inputString.ToCharArray().Any(c => Char.IsLetterOrDigit(c));
    }
