    public static String ChrTran(
       String input, String searchPattern, String replacementPattern)
    {
        return new String(input.
            Where(symbol =>
                !searchPattern.Contains(symbol) ||
                searchPattern.IndexOf(symbol) < replacementPattern.Length).
            Select(symbol =>
                searchPattern.Contains(symbol)
                    ? replacementPattern[searchPattern.IndexOf(symbol)]
                    : symbol).
            ToArray());
    }
