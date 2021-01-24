    private static string MutateToMidnight(string source)
    {
        var pieces = source.Split(new char[] { 'T' });
        if (pieces.Length == 0 && pieces[0].EndsWith("Z", StringComparison.InvariantCultureIgnoreCase))
        {
            return pieces[0];
        }
        return pieces[0] + "Z";
    }
