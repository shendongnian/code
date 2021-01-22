    private static string[] SplitBy(string source, int count)
    {
        const char Separator = '╩';
        var byCount = source.Select((c, i) => i % count == 0 ? Separator : c).ToArray();
        var inString = new string(byCount);
        return inString.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
    }
