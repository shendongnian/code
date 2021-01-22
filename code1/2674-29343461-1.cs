    public static bool TryConvertToEnum<T>(this int instance, out T result)
      where T: struct
    {
      var enumType = typeof (T);
      if (!enumType.IsEnum)
      {
        throw new ArgumentException("The generic type must be an enum.");
      }
      var success = Enum.IsDefined(enumType, instance);
      if (success)
      {
        result = (T)Enum.ToObject(enumType, instance);
      }
      else
      {
        result = default(T);
      }
      return success;
    }
