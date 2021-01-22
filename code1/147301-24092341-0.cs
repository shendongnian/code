    private static string ReplaceNamedGroup(
        string input, string groupName, string replacement, Match m)
    {
        var sb = new StringBuilder(m.Value);
    
        var captures = m.Groups[groupName].Captures.OfType<Capture>();
        foreach (var capt in captures)
        {
            if (capt == null)
                continue;
    
            sb.Remove(capt.Index, capt.Length);
            sb.Insert(capt.Index, replacement);
        }
    
        return sb.ToString();
    }
