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
                //you can throw an exception if the string does not exist in the enum
                throw new InvalidCastException();
                //If you prefer to return the first available enum as the default value then do this
               Enum.GetNames(typeof (T))[0].ConvertToEnum<T>(); //Note: I haven't tested this
            }
            return (T)Enum.Parse(typeof(T), value);
        }
    }
