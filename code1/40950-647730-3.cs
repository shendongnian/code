    public static bool IsNullOrEmpty(this String value, bool checkTrimmed)
    {
      var b = String.IsNullOrEmpty(value);
      return checkTrimmed ? (b && value.Trim().Length > 0) : b;
    }
