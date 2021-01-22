    namespace System
    {
        public static class StringExtensions
        {
    
            public static bool TryParseAsEnum<T>(this string value, out T output) where T : struct
            {
                T result;
    
                var isEnum = Enum.TryParse(value, out result);
        
                output = isEnum ? result : default(T);
    
                return isEnum;
            }
        }
    }
