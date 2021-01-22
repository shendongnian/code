    public static String ChrTran(String input, String source, String destination)
    {
        return source.Aggregate(
            input,
            (current, symbol) => current.Replace(
                symbol,
                destination.ElementAtOrDefault(source.IndexOf(symbol))),
            preResult => preResult.Replace("\0", String.Empty));
    }
