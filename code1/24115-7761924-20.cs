        public static bool IsObjectNullable<T>(T obj)
        {
            // If the parameter-Type is a reference type, or if the parameter is null, then the object is always nullable
            if (!typeof(T).IsValueType || obj == null)
                return true;
            // Since the object passed is a ValueType, and it is not null, it cannot be a nullable object
            return false; 
        }
        public static bool IsObjectNullable<T>(T? obj) where T : struct
        {
            // Always return true, since the object-type passed is guaranteed by the compiler to always be nullable
            return true;
        }
