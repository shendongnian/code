    public static class EnumExtensions
    {
        internal static string GetDisplayName<T>(this T enumValue) //where T : struct, IComparable, IFormattable, IConvertible
        {
            return enumValue.GetType()?
                            .GetMember(enumValue.ToString())?
                            .First()?
                            .GetCustomAttribute<DisplayAttribute>()?
                            .GetName() ?? enumValue.ToString();
        }
        public static string GetEnumDisplayName<T>(this T value) //where T : struct, IComparable, IFormattable, IConvertible
        {
            return GetDisplayName(value);
        }
    }
