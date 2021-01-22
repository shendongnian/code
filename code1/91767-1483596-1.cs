    public static Dictionary<string, string> SplitToDictionary(string input)
    {
        Regex regex = new Regex(@"\[([^\]]+)\]([^\[]+)");
    
        Dictionary<string, string> result = new Dictionary<string, string>();
        foreach (Match match in regex.Matches(input))
        {
            result.Add(match.Groups[1].Value, match.Groups[2].Value.Trim());
        }
    
        return result;
    }
