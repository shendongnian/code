    public string TrimString(string s, int maxLength)
    {
        var pos = s.Select((c, idx) => new { Char = c, Pos = idx })
            .Where(item => char.IsWhiteSpace(item.Char) && item.Pos <= maxLength)
            .Select(item => item.Pos)
            .SingleOrDefault();
        return pos > 0 ? s.Substring(0, pos) : s;
    }
