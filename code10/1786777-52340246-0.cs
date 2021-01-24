    using System.Text.RegularExpressions;
    ...
    MatchCollection matches = Regex.Matches("Hello this is a {Testvar}... and we have more {Tagvar} in this string {Endvar}.", @"{([\d\w]+)}");
    foreach(Match match in matches){
        Console.WriteLine("match : {0}, index : {1}", match.Groups[1], match.index);
    }
