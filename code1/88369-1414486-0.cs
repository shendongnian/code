    public static bool IsValid(this string value)
    {
      DateTime date = DateTime.Null;
      return DateTime.TryParse(value, out date);
    }
