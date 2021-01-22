    using System.Text.RegularExpressions;
    Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
    Match result = re.Match(input);
    string alphaPart = result.Groups[1].Value;
    string numberPart = result.Groups[2].Value;
