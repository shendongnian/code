      using System.Linq;  
      using System.Text.RegularExpressions;
      ...
      string ab = "Seq [A=255, B=0, C=0, D=0]";
      Dictionary<string, int> vars = Regex
        .Matches(ab, @"(?<Name>[A-Za-z]+)\s*=\s*(?<Value>-?[0-9]+)")
        .OfType<Match>()
        .ToDictionary(match => match.Groups["Name"].Value,
                      match => int.Parse(match.Groups["Value"].Value),
                      StringComparer.OrdinalIgnoreCase);
