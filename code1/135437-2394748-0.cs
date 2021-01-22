    public static object TryParse(Type enumType, string value, out bool success)
    {
      success = Enum.IsDefined(enumType, value);
      if (success)
      {
        return Enum.Parse(enumType, value);
      }
      return null;
    }
