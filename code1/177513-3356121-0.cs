        public static class StringExtensions
        {
        public static T ConvertToEnum<T>(this string value)
        {
            //Guard condition to not allow this to be used with any other type than an Enum
            if (typeof(T).BaseType != typeof(Enum))
            {
                throw new InvalidCastException(string.Format("ConvertToEnum does not support converting to type of [{0}]", typeof(T)));
            }
            if (Enum.IsDefined(typeof(T), value) == false)
            {
                throw new InvalidCastException();
            }
            return (T)Enum.Parse(typeof(T), value);
        }
    }
