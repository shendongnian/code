    public static TValue ParseEnum<TValue>(string value, TValue defaultValue)
                      where TValue : struct // enum 
    {
          try
          {
                if (String.IsNullOrEmpty(value))
                      return defaultValue;
                return (TValue)Enum.Parse(typeof (TValue), value);
          }
          catch(Exception ex)
          {
                return defaultValue;
          }
    }
