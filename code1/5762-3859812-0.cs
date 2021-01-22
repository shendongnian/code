    public static IEnumerable<TEnum> GetEnumValues()
    {
      TEnum typeDefault = default(TEnum);
      Type enumType = typeDefault.GetType();
    
      if(!enumType.IsEnum)
        throw new ArgumentException("Type argument must be Enum type");
    
      Array enumValues = Enum.GetValues(enumType);
      return enumValues.Cast<TEnum>();
    }
