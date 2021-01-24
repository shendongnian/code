    public static string Remove(string original, string firstTag, string secondTag)
    {
       string pattern = firstTag + "(.*?)" + secondTag;
       Regex regex = new Regex(pattern, RegexOptions.RightToLeft);
            
       foreach(Match match in regex.Matches(original))
       {
          original = original.Replace(match.Groups[1].Value, string.Empty);
       }
            
       return original;
    }
