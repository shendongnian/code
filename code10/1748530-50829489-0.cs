    string inputString = "=HYPERLINK(CONCATENATE(\"https://abc.efghi.rtyui.com/#/wqeqwq/\",#REF!,\"/asdasd\"), \"View asdas\")";
    string regex = "CONCATENATE\\(\"([\\S]+)\",#REF!,\"([\\S]+)\"\\)";
    Regex substringRegex = new Regex(regex, RegexOptions.IgnoreCase);
    Match substringMatch = substringRegex.Match(inputString);
    if (substringMatch.Success)
    {
        string url = substringMatch.Groups[1].Value + "#REF!" + substringMatch.Groups[2].Value;
    }  
