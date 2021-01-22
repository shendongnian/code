    public static bool TryParseEnum<TEnum>(this int enumValue, out TEnum retVal)
    {
     retVal = default(TEnum);
     bool success = Enum.IsDefined(typeof(TEnum), enumValue);
     if (success)
     {
      retVal = (TEnum)Enum.ToObject(typeof(TEnum), enumValue);
     }
     return success;
    }
