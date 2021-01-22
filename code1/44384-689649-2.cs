    public static string ProperSpace(string text)
    {
      var expression = new Regex("[A-Z]");
      return expression.Replace(text, " $0");
    }
