    public static bool ContainsOnlySymbols(string inputString)
    {
        // Go through the characters of the input string checking for symbols
        return inputString.All(c => Char.IsSymbol(c) || Char.IsPunctuation(c));
    }
