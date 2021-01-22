    string input = @"\tid 01CA4692.A44F1F3E@blah.blah.co.uk; Tue, 6 Oct 2009 15:38:16 +0100";
    // to capture offset too, add "\s+\+\d+" at the end of the pattern below
    string pattern = @"[A-Z]+,\s+\d+\s+[A-Z]+\s+\d{4}\s+(?:\d+:){2}\d{2}";
    Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
    if (match.Success)
    {
        string result = match.Value.Dump();
        DateTime parsedDateTime;
        if (DateTime.TryParse(result, out parsedDateTime))
        {
            // successful parse, date is now in parsedDateTime
            Console.WriteLine(parsedDateTime.ToString("dd-MM-yyyy hh:mm:ss"));
        }
        else
        {
            // parse failed, throw exception
        }
    }
    else
    {
        // match not found, do something, throw exception
    }
