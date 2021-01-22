    static class EnumHelpers<T> where T : struct
    {
        public class NotAnEnumException : Exception
        {
            public NotAnEnumException() : base(string.Format(@"Type ""{0}"" is not an Enum type.", typeof(T))) { }
        }
    
        static EnumHelpers()
        {
            if (typeof(T).BaseType != typeof(Enum)) throw new NotAnEnumException();
        }
    
        public static IEnumerable<T> GetValues()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    
        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
