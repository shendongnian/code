    public static class EnumUtils
    {
            public static bool TryParse<TEnum>(int? value, out TEnum result)
                where TEnum: struct, IConvertible
            {
                if(!value.HasValue || !Enum.IsDefined(typeof(TEnum), value)){
                    result = default(TEnum);
                    return false;
                }
                result = (TEnum)Enum.ToObject(typeof(TEnum), value);
                return true;
            }
    }
    
