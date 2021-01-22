    public static class StringUtility
    {
      public static string Format(string pattern, IDictionary<string, object> args)
      {
        StringBuilder builder = new StringBuilder(pattern);
        foreach (var arg in args)
        {
          builder.Replace("{" + arg.Key + "}", arg.Value.ToString());
        }
        return builder.ToString();
      }
    }
