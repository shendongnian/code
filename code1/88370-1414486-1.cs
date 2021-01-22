    public static bool IsValidDate(this string value)
    {
      DateTime date = DateTime.Null;
      return DateTime.TryParse(value, out date);
    }
