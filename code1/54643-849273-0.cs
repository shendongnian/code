    private static string ChrTran(
       String input, String searchPattern, String replacementPattern)
    {
        return searchPattern.Aggregate(
            input,
            (current, symbol) => current.Replace(
                symbol,
                replacementPattern.ElementAtOrDefault(
                    searchPattern.IndexOf(symbol))),
            preResult => preResult.Replace("\0", String.Empty));
    }
