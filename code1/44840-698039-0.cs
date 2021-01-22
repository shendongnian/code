    public static class DecimalExtensions
    {
      public static decimal TruncateDecimal(this decimal @this, int places)
      {
        int multipler = (int)Math.Pow(10, places);
        return Decimal.Truncate(@this * multipler) / multipler;
      }
    }
