    public static SamToken Parse(string str)
    {
        if (String.IsNullOrEmpty(str))
            return null;
        Match match = Regex.Match(str, @"^(\w*)\[([\w|]*)\]$");
        if (!match.Success)
            return null;
        SamToken token = new SamToken(match.Groups[1].Value);
        token.Add(match.Groups[2].Value.Split('|'));
        return token;
    }
