    private static string CleanErlangString(string toClean)
    {
        return toClean
            .Replace("{", "").Replace("}", "")
            .Replace("\"", "")
            .Replace("<<", "").Replace(">>", "");
    }
