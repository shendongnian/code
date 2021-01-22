    Regex parseLine = new Regex(@"(?<num1>\d+)\:(?<num2>\d+)\,(?<num3>\d+)", RegexOptions.Compiled);
    foreach (string line in File.ReadAllLines(yourFilePath))
    {
      var match = parseLine.Match(line);
      if (match.Success) {
        var num1 = match.Groups["num1"].Value;
        var num2 = match.Groups["num2"].Value;
        var num3 = match.Groups["num3"].Value;
        // use the values.
      }
    }
