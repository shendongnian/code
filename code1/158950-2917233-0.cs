    public static bool IsNumeric(string input)
    {
      int dummy;
      return int.TryParse(input, out dummy);
    }
