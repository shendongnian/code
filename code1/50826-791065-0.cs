    public static class BarExtensions
    {
      public static string ToStringOr(this bar, string whenNull)
      {
        return bar == null ? whenNull ?? "[null]" : bar.ToString();
      }
    }
