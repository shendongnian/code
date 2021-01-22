    public static bool TryConvertToEnum<T>(this int instance, out T result)
      where T: Enum
    {
      var enumType = typeof (T);
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
