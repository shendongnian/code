    // Not a fan of the 'out' usage but I am not sure if you care about the result success
    public static bool AddSpacesToMyRegexMatch(string input, out string output)
    {
        Regex reg = new Regex(@"(^clp\*[0-9]{7})(1\*$)");
        Match match = reg.Match(input);
        output = match.Success ?
            string.Format("{0}  {1}", match.Groups[0], match.Groups[1]) :
            input;
        return match.Success;
    }
