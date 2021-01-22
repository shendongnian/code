    Regex getParamRegex = new Regex(@"(?<param>:\w*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    string input = "select * from table where a = :param1 and b = :param2";
            
    var allMatches = getParamRegex.Matches(input);
    foreach (var match in allMatches)
    {
       string work = match.ToString();
    }
