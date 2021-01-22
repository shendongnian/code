    public static class StringExtensions {
        public static T ConvertToEnum<T>(this string value)  {
            Contract.Requires(typeof(T).IsEnum);
            Contract.Requires(value != null);
            Contract.Requires(Enum.IsDefined(typeof(T), value));
            return (T)Enum.Parse(typeof(T), value);
        }
    }
