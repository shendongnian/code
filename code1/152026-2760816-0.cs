    public Dictionary<string, double> ParseString(string input){
        var dict = new Dictionary<string, double>();
        try
        {
            var re = new Regex(@"(?:\(params\s)?(?:\((?<n>[^\s]+)\s(?<v>[^\)]+)\))");
            foreach (Match m in re.Matches(input))
                dict.Add(m.Groups["n"].Value, double.Parse(m.Groups["v"].Value));
        }
        catch
        {
            throw new Exception("Invalid format!");
        }
        return dict;
    }
