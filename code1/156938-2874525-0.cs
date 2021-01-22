    string resultString = "New York (New York)";
    Regex regexObj = new Regex(@"(?<City>[^(]*)(?<PR>\([^)]*\))",RegexOptions.IgnoreCase);
    var match = regexObj.Match(subjectString);
    if (match.Success)
    {
      string city = match.Groups["City"].Value;
      string province = match.Groups["PR"].Value;
    }
