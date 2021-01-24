      using System.Text.RegularExpressions;
      using System.Linq;
      ...
      string text = ...;
      string[] ids = Regex
        .Matches(text, "(?:id=)(?<value>[0-9]+)(?:&amp)")
        .OfType<Match>()
        .Select(match => match.Groups["value"].Value)
        .ToArray();
