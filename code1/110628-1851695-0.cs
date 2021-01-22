    var regex = new Regex(@"\""([^\""]*)\""");
    foreach(string x in strings)
    {
        var matches = regex.Matches(x);
        if (matches.Count > 0)
        {
            var matchedValue = matches[0].Groups[1].Value;
            z.Append(matchedValue);
        }
    }
