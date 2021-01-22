    public static bool IsNullOrEmpty(this String str, bool checkTrimmed)
    {
      var b = String.IsNullOrEmpty(str);
      return checkTrimmed ? b && str.Trim().Length == 0 : b;
    }
