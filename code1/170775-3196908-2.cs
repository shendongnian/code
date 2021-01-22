    public static class StringExtensions {
      // maybe just call it Split
      public static string[] SplitAndRemoveEmptyEntries(this string self, params string[] separators) {
        return self.Split(separators, StringSplitOptions.RemoveEmptyEntries);
      }
    }
