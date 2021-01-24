      using System.IO;
      using System.Linq;
      using System.Text.RegularExpressions;
      ...
      string[] result = File
        .ReadLines(@"c:\MyFile.txt")
        .Select(line => Regex.Match(line, "^[A-Z][0-9]{7}"))
        .Where(match => match.Success)
        .Select(match => match.Value)
        .ToArray();
