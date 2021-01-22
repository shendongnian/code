    public static class ExtensionMethods {
      public static string Multiply(this string text, int count)
      {
        return new string(Enumerable.Repeat(text, count)
          .SelectMany(s => s.ToCharArray()).ToArray());
      }
    }
