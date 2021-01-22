    string input = "FindbcFinddefFind", pattern = "Find";
    int i = 1;
    string replaced = Regex.Replace(input, pattern, delegate(Match match)
    {
        string s = match.Value.ToUpper() + i;
        i++;
        return s;
    });
