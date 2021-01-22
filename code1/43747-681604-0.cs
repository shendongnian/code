    using System.Text.RegularExpressions;
    string pattern = @"([A-Za-z]+)(\d+)";
    string foo = "freq12";
    Match match = Regex.Match(foo, pattern);
    string fooPart = match.Groups[1].Value;
    int fooNumber  = int.Parse(match.Groups[2].Value);
