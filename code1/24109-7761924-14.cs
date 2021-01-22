        public static bool IsObjectNullable<T>(T t)
        {
            if (t == null || !t.GetType().IsValueType)
                return true;
            return false; 
        }
        public static bool IsObjectNullable<T>(T? t) where T : struct 
        { 
            return true; 
        } 
