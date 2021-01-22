    using System;
    using System.Text.RegularExpressions;
    
    private IEnumerable<string> GetSubStrings(string input, string start, string end)
    {
        Regex r = new Regex(Regex.Escape(start) +`"(.*?)"`  + Regex.Escape(end));
        MatchCollection matches = r.Matches(input);
        foreach (Match match in matches)
        yield return match.Groups[1].Value;
    }
