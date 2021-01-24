    Regex pattern = new Regex(@"(?<num>\d{3})card.json");
    Match match = pattern.Match(qnaResult.ToLower());
    if (match.Success)
    {
        string num = pattern.Groups["num"].Value;
        // Do something with num
    }
    else
    {
        // No match
    }
