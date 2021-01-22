    public static string ReplaceNamedGroup(
        string input, string groupName, string replacement, Match match)
    {
        var sb = new StringBuilder(input);
        var matchStart = match.Index;
        var matchLength = match.Length;
        var captures = match.Groups[groupName].Captures.OfType<Capture>()
            .OrderByDescending(c => c.Index);
        foreach (var capt in captures)
        {
            if (capt == null)
                continue;
            matchLength += replacement.Length - capt.Length;
            sb.Remove(capt.Index, capt.Length);
            sb.Insert(capt.Index, replacement);
        }
        var end = matchStart + matchLength;
        sb.Remove(end, sb.Length - end);
        sb.Remove(0, matchStart);
        return sb.ToString();
    }
