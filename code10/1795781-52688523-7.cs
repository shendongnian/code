    private static bool Validate(Match match)
    {
        if(!match.Success)
        {
            return false;
        }
        var day = match.Groups[1].ToString();
        var month = match.Groups[2].ToString();
        var year = match.Groups[3].ToString();
        return DateTime.TryParse($"{day}-{month}-{year}", out _);
    }
