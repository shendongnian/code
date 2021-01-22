    Usage: Dictionary<string, string> dict = queryToDictionary("userid=abc&password=xyz&retain=false", '&', '=');
    public static Dictionary<string, string> queryToDictionary(string line, char lineSplit, char keyValueSplit)
    {
        return line.Split(new[] { lineSplit }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split(new[] { keyValueSplit })).ToDictionary(x => x[0], y => y[1]); ;
    }
