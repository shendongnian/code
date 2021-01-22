    StringCollection resultList = new StringCollection();
    Regex regexObj = new Regex(@"""(\\""|\\\\|\\|[^""\\])*""");
    Match matchResult = regexObj.Match(subjectString);
    while (matchResult.Success) {
        resultList.Add(matchResult.Value);
        matchResult = matchResult.NextMatch();
    } 
