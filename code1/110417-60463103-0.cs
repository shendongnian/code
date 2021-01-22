        public static Type GetEnumerableArgumentType(Type type)
        {
            if (type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                return type.GetGenericArguments()[0];
            else
                return null;            
        }        
        public static bool EnumerableContainsArgumentType(Type tEnumerable, Type tGenArg)
        {
            return GetEnumerableType(tEnumerable) == tGenArg;
        }
