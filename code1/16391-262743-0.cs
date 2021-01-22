    static string Search(string expression)
    {
      int run = 0;
      for (int i = 0; i < expression.Length; i++)
      {
        char c = expression[i];
        if (Char.IsDigit(c))
          run++;
        else if (run == 5)
          return expression.Substring(i - run, run);
        else
          run = 0;
      }
      return null;
    }
    const string pattern = @"\d{5}";
    static string NotCached(string expression)
    {
      return Regex.Match(expression, pattern, RegexOptions.Compiled).Value;
    }
    static Regex regex = new Regex(pattern, RegexOptions.Compiled);
    static string Cached(string expression)
    {
      return regex.Match(expression).Value;
    }
