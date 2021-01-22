    private static string RemoveDuplicateSpaces(string text) {
      StringBuilder b = new StringBuilder(text.Length);
      bool space = false;
      foreach (char c in text) {
        if (c == ' ') {
          if (!space) b.Append(c);
          space = true;
        } else {
          b.Append(c);
          space = false;
        }
      }
      return b.ToString();
    }
