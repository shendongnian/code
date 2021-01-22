    public static String ChrTran(String input, String source, String destination)
    {
        return new String(input.
            Where(symbol =>
                !source.Contains(symbol) ||
                source.IndexOf(symbol) < destination.Length).
            Select(symbol =>
                source.Contains(symbol)
                    ? destination[source.IndexOf(symbol)]
                    : symbol).
            ToArray());
    }
