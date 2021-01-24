        private static bool MatchesPattern(string text, string pattern)
    {
      List<string> patternTokens = new List<string>();
      string tok = "";
      pattern = pattern.ToLower() + "[";
      int state = 0;
      for(int i = 0; i < pattern.ToCharArray().Length; i++)
      {
        char token = pattern[i];
        if(token == '[')
        {
          if(tok != "")
          {
            patternTokens.Add("NEC" + char.MaxValue + tok);
            tok = "";
          }
          state = 1;
          continue;
        }
        if(token == ']' && state == 1)
        {
          i++;
          state = 0;
          patternTokens.Add("OPT" + char.MaxValue + tok);
          tok = "";
          continue;
        }
        if(token == ' ' && i + 1 < text.ToCharArray().Length && text[i + 1] == '[')
          continue;
        tok += token;
      }
      string[] patternTokensCopy = new string[patternTokens.Count];
      for(int i = 0; i < patternTokens.Count; i++)
        patternTokensCopy[i] = patternTokens[i];
      int max = (int) Math.Pow(2, patternTokens.Where(x => x.StartsWith("OPT")).ToList().Count);
      for(int i = 0; i < max; i++)
      {
        string binary = Convert.ToString(i, 2).PadLeft(patternTokensCopy.Where(x => x.StartsWith("OPT")).ToList().Count, '0');
        for(int x = 0; x < patternTokensCopy.Where(t => t.StartsWith("OPT")).ToList().Count; x++)
          if(binary[x] == '0')
          {
            List<string> optionalTokens = new List<string>();
            foreach(string curpattern in patternTokensCopy)
              if(curpattern.StartsWith("OPT"))
                optionalTokens.Add(curpattern);
            patternTokens.Remove(optionalTokens[x]);
          }
        string patternAsSentence = "";
        foreach(string patternToken in patternTokens)
          patternAsSentence += patternToken.Split(char.MaxValue)[1] + " ";
        while(patternAsSentence[patternAsSentence.Length - 1] == ' ')
          patternAsSentence = patternAsSentence.Substring(0, patternAsSentence.Length - 1);
        patternAsSentence = patternAsSentence.Replace("\r", "").Replace("  ", " ");
        int similarity = StringSimilarity.GetStringSimilarity(patternAsSentence, text);
        if(text.Length < 6)
        {
          if(text == patternAsSentence)
            return true;
        }
        else
        {
          if(similarity <= 6)
            return true;
        }
        patternTokens = new List<string>();
        patternTokensCopy.ToList().ForEach(x => patternTokens.Add(x));
      }
      return false;
    }
