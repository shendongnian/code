    string pattern = @"\(([^)]*)\)";
    string expressions = "(4*20+4*5), (3*20+7*5), (9*10+1*5), (9*10+10*5)";
    List<string> validCombinations = new List<string>();
    Regex regex = new Regex(pattern);
    foreach (Match match in regex.Matches(expressions))
    {
          // Remove parentheses
          string expression = match.Groups[1].Value;
          System.Data.DataTable table = new System.Data.DataTable();
          string result = table.Compute(expression, string.Empty).ToString();
          if (double.TryParse(result, out double res) && res <= 100)
          {
               validCombinations.Add(match.Value);
          }
     }
     var final = string.Join(",", validCombinations);
