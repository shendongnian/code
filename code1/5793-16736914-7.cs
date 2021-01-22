    public static class EnumUtils
    {
        public static TEnum ParseEnum<TEnum>(this string value,
                                             bool ignoreCase = true,
                                             TEnum defaultValue = default(TEnum))
            where TEnum : struct,  IComparable, IFormattable, IConvertible
        {
            if ( ! typeof(TEnum).IsEnum) { throw new ArgumentException("TEnum must be an enumerated type"); }
            if (string.IsNullOrEmpty(value)) { return defaultValue; }
            TEnum lResult;
            if (Enum.TryParse(value, ignoreCase, out lResult)) { return lResult; }
            return defaultValue;
        }
    }
