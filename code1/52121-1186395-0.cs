    public static bool IsNullOrEmpty(this String str, bool checkTrimmed)
    {
      var b = String.IsNullOrEmpty(str);
      return checkTrimmed ? b && str.Trim().Lenght == 0 : b;
    }
