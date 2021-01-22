    public static IEnumerable<TEnum> GetEnumValues()
    {
      Type enumType = typeof(TEnum);
    
      if(!enumType.IsEnum)
        throw new ArgumentException("Type argument must be Enum type");
    
      Array enumValues = Enum.GetValues(enumType);
      return enumValues.Cast<TEnum>();
    }
