    public static Dictionary<string, string> SplitToDictionary(string input)
    {
        Regex regex = new Regex(@"\[([^\]]+)\]([^\[]+)");
    
        return regex.Matches(input).Cast<Match>().ToDictionary(x => x.Groups[1].Value, x => x.Groups[2].Value.Trim());
    }
