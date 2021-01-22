    public static bool RegExValidate(string text, string regex)
    {
      if (!regexCache.ContainsKey(regex))
      {
        Regex compiledRegex = new Regex(regex,RegexOptions.Compiled);
        regexCache.Add(regex, compiledRegex);
      }
      return regexCache[regex].IsMatch(text);
    }
