    public static class StringExtensions
    {
      public static bool IsDigits(this String text)
      {
        return !text.Any(c => !char.IsDigit(c));
      }
    }
