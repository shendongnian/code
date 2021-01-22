    // Determine whether the input value is a number
    public static bool IsNumeric(string someValue)
    {
      return new Regex(@"^[-+]?(\d*\.)?\d+$").IsMatch(someValue);
    }
