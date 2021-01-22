    Regex usPhoneRegex = new Regex(@"(\d{3})(\d{3})(\d{4})(.*)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    return usPhoneRegex.Replace("3125882300", new MatchEvaluator(MyClass.formatPhone))
    public static string formatPhone(Match m) {
      int groupIndex = 0;
      string results = string.Empty;
      foreach (Group g in m.Groups) {
        groupIndex +=1;
        switch (groupIndex) {
          case 2 : 
            results = g.Value;
            break;
          case 3 : 
          case 4 : 
            results += "-" + g.Value;
            break;
          case 5 :
            if (g.Value.Length != 0) {
              results += " x " + g.Value;
            }
            break;
        }
      }
      return results;
    }
