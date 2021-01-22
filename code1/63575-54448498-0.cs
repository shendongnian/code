    public static class EnumExt
    {
        public static IEnumerable<TEnum> Explode<TEnum>(this TEnum enumValue) where TEnum : Enum
        {
            var res = Enum.GetValues(enumValue.GetType())
                .Cast<TEnum>()
                .Where(x => enumValue.HasFlag(x));
            return res;
        }
    
        public static string ExplodeToString<TEnum>(this TEnum enumValue, string delimeter = ",") where TEnum : Enum
        {
            return string.Join(delimeter, Explode(enumValue));
        }
    }
