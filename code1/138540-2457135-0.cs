    var pattern = "^(\(x[+-]\d+(\.\d+)?\)){2}$");
    var input = "(x-0.123)(x+5)";
    var result = System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
    if (result) { 
      Console.Write("YAY IT MATCHES");
    }
