    public static class StringExtension
    {
      public static String InsertDecimal(this String @this, Int32 precision)
      {
        String padded = @this.PadLeft(precision, '0');
        return padded.Insert(padded.Length - precision, ".");
      }
    }
    // Usage
    "3000".InsertDecimal(2);
