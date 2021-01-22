    public static TEnum ConvertEnum<TEnum >(this Enum source)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), source.ToString(), true);
        }
    // Usage
    NewEnumType newEnum = oldEnumVar.ConvertEnum<NewEnumType>();
