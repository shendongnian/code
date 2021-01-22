    public static string ToCurrencyString (this decimal value)
    {
      if (value == 0)
        return String.Empty;
      return value.ToString ("C");
    }
