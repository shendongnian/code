    Regex regex = new Regex(pattern);
    MatchCollection mc = regex.Matches(haystack);
    for (int i = 0; i < mc.Count; i++)
    {
         GroupCollection gc = mc[i].Groups;
         Dictionary<string, string> match = new Dictionary<string, string>();
         for (int j = 0; j < gc.Count; j++)
         {
            match.Add(regex.GroupNameFromNumber(j), gc.Value);
         }
         this.matches.Add(i, match);
    }
