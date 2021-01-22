    public static class StringExtensions {
        public static T ConvertToEnum<T>(this string value)  {
            if (typeof(T).BaseType != typeof(Enum)) {
                throw new InvalidCastException();
            }
            if(Enum.IsDefined(typeof(T), value) == false) {
                throw new InvalidCastException();
            }
            return (T)Enum.Parse(typeof(T), value);
        }
    }
