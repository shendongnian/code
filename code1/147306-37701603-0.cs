    private static string ReplaceNamedGroup(string input, string groupName, string replacement, Match m)
    {
      string result = m.Value;
      foreach (Capture cap in m.Groups[groupName]?.Captures)
      {
        result = result.Remove(cap.Index - m.Index, cap.Length);
        result = result.Insert(cap.Index - m.Index, replacement);
      }
    return result;
    }
