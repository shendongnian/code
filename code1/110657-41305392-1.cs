    Usage: Dictionary<string, string> dict = stringToDictionary("userid=abc&password=xyz&retain=false");
    public static Dictionary<string, string> stringToDictionary(string line, char stringSplit = '&', char keyValueSplit = '=')
    {
        return line.Split(new[] { stringSplit }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split(new[] { keyValueSplit })).ToDictionary(x => x[0], y => y[1]); ;
    }
