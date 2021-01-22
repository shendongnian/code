    static string ToLowerExceptFirstLetter(string value)
    {
      if (string.IsNullOrEmpty(value))
        return value;
      if (value.Length > 1)
        return value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
      else
        return value.ToUpper();
    }
