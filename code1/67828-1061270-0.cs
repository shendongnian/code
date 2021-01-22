    public static class StringExtensions {
        public static T ConvertToEnum<T>(this string value)  {
            if (typeof(T) != typeof(Enum)) {
                throw new InvalidCastException();
            }
            return (T)Enum.Parse(typeof(T), value);
        }
    }
