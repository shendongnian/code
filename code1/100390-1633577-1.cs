      public string ReplaceData(Match m)
      {
          return pairs[m.Value];         
      }
...
      pairs.Add("foo","bar");
      pairs.Add("homer","simpson");
      Regex r = new Regex("(?>foo|homer)");
      MatchEvaluator myEval = new MatchEvaluator(class.ReplaceData);
      string sOutput = r.Replace(sInput, myEval);
