    private static string[] SplitBy(string source, int count)
    {
        const string Separator = "╩";
        var byCount = source.Select((c, i) => i % count == 0 ? Separator + c : c.ToString()).ToArray();
        var inString = string.Join(string.Empty, byCount);
        return inString.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
    }
