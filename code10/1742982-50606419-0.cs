    private static String MyReplace(string value, params Tuple<string, string>[] substitutes) {
      if (string.IsNullOrEmpty(value))
        return value;
      else if (null == substitutes || !substitutes.Any())
        return value;
      int start = 0;
      StringBuilder sb = new StringBuilder();
      while (true) {
        int at = -1;
        Tuple<string, string> best = null;
        foreach (var pair in substitutes) {
          int index = value.IndexOf(pair.Item1, start);
          if (index >= 0)  
            if (best == null || 
                index < at || 
                index == at && best.Item1.Length < pair.Item1.Length) { 
              at = index;
              best = pair;
            }
        }
        if (best == null) {
          sb.Append(value.Substring(start));
          break;
        }
        sb.Append(value.Substring(start, at - start));
        sb.Append(best.Item2);
        start = best.Item1.Length + at;
      }
      return sb.ToString();
    }
