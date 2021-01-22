    public static class StringExtensions
    {
        public static TEnum ToEnum<TEnum>(this string text)
            where TEnum : struct, IComparable, IFormattable, IConvertible 
        {
            TEnum result = default(TEnum);
            return !string.IsNullOrWhiteSpace(text) 
                && Enum.TryParse(text, true, out result)
                && Enum.IsDefined(typeof(TEnum), result.ToString())
                    ? result
                    : default(TEnum);
        }
    }
