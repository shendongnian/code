    public static class StringExt
    {
      public static string Truncate( this string value, int maxLength )
      {
          return value.Substring(0, Math.Min(value.length, maxLength));
      }
    }
