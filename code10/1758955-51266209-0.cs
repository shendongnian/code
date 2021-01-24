        public string Format(string s)
        {
          string strRegex = @"[\t]+";
          Regex myRegex = new Regex(strRegex, RegexOptions.None);
          string strReplace = @"[\t]";
          return myRegex.Replace(s, strReplace);
        }
