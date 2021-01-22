        public static bool IsObjectNullable<T>(T obj)
        {
            Type argType = typeof(T);
            if (!argType.IsValueType || obj == null)
                return true;
            return argType.IsGenericType && argType.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
