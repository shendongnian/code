    using System.Text.RegularExpressions;
    // ... more code
    string templateString = "{0} {2} .{{99}}. {3}"; 
    Match match = Regex.Matches(templateString, 
                 @"(?<!\{)\{(?<number>[0-9]+).*?\}(?!\})")
                .Cast<Match>()
                .OrderBy(m => m.Groups["number"].Value)
                .LastOrDefault();
    Console.WriteLine(match.Groups["number"].Value); // Display 3
