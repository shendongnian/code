        public static bool InheritsFrom(this Type t1, Type t2)
        {
            if (null == t1 || null == t2)
                return false;
            if (null != t1.BaseType &&
                t1.BaseType.IsGenericType &&
                t1.BaseType.GetGenericTypeDefinition() == t2)
            {
                return true;
            }
            if (InheritsFrom(t1.BaseType, t2))
                return true;
            
            return
                (t2.IsAssignableFrom(t1) && t1 != t2)
                ||
                t1.GetInterfaces().Any(x =>
                  x.IsGenericType &&
                  x.GetGenericTypeDefinition() == t2);
        }
