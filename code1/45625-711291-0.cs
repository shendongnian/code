    public static class StringExtension
    {
      public static string InsertDecimal(this string @this, int precision)
      {
        var padded = @this.PadRight(precision, '0');
        return padded.Insert(padded.Length - 2, ".");
      }
    }
    // Usage
    "3000".InsertDecimal(2);
