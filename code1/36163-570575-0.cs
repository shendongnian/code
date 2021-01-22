    private static string Surround(string original, string head, string tail, string match, StringComparison comparisonType)
    {
      if (string.IsNullOrEmpty(original) || string.IsNullOrEmpty(match) || (string.IsNullOrEmpty(head) && string.IsNullOrEmpty(tail)))
        return original;
      var resultBuilder = new StringBuilder();
      int matchLength = match.Length;
      int lastIdx = 0;
      for (;;)
      {
        int curIdx = original.IndexOf(match, lastIdx, comparisonType);
        if (curIdx > -1)
          resultBuilder
            .Append(original, lastIdx, curIdx - lastIdx)
            .Append(head)
            .Append(original, curIdx, matchLength)
            .Append(tail);
        else
          return resultBuilder.Append(original.Substring(lastIdx)).ToString();
        lastIdx = curIdx + matchLength;
      }
    }
