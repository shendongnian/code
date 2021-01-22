    public static string ToLowerExceptFirstLetter(string value)
    {
      if (value == null || value.Length <= 1)
        return value;
      return value.Substring(0, 1) + value.Substring(1).ToLower();
    }
