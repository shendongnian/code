    public static bool TryConvertToEnum<T>(this int instance, out T result)
      where T: struct
    {
      var enumType = typeof (T);
      if (!enumType.IsEnum)
      {
        throw new ArgumentException("The generic type must be an enum.");
      }
      var remainingValue = instance;
      remainingValue =
        Enum.GetValues(enumType)
          .Cast<int>()
          .OrderByDescending(n => n)
          .Where(value => instance >= value)
          .Aggregate(remainingValue, (current, value) => current - value);
      var success = remainingValue == 0;
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
