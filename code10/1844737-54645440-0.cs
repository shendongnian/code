      using System.Text.RegularExpressions; 
      ...
      // Let's extract operations collection 
      // key: operation name, value: operation itself 
      Dictionary<string, Func<string, string, string>> operations =
        new Dictionary<string, Func<string, string, string>>() {
        { "<<", (x, y) => (long.Parse(x) << int.Parse(y)).ToString() },
        { ">>", (x, y) => (long.Parse(x) >> int.Parse(y)).ToString() }
      };
      string source = "2 << 1";
      var match = Regex.Match(source, @"(-?[0-9]+)\s*(\S+)\s(-?[0-9]+)");
      string result = match.Success
        ? operations.TryGetValue(match.Groups[2].Value, out var op) 
           ? op(match.Groups[1].Value, match.Groups[3].Value)
           : "Unknown Operation"  
        : "Syntax Error";
      // 4
      Console.Write(result);
