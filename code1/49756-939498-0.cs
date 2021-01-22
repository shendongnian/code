        public static T To<T>(this IConvertible obj)
        {
            Type t = typeof(T);
            if (t.IsGenericType
                && (t.GetGenericTypeDefinition() == typeof(Nullable<>)))
            {
                if (obj == null)
                {
                    return (T)(object)null;
                }
                else
                {
                    return (T)Convert.ChangeType(obj, Nullable.GetUnderlyingType(t));
                }
            }
            else
            {
                return (T)Convert.ChangeType(obj, t);
            }
        }
        public static T ToOrDefault<T>
                     (this IConvertible obj)
        {
            try
            {
                return To<T>(obj);
            }
            catch
            {
                return default(T);
            }
        }
        public static bool ToOrDefault<T>
                            (this IConvertible obj,
                             out T newObj)
        {
            try
            {
                newObj = To<T>(obj);
                return true;
            }
            catch
            {
                newObj = default(T);
                return false;
            }
        }
        public static T ToOrOther<T>
                               (this IConvertible obj,
                               T other)
        {
            try
            {
                return To<T>(obj);
            }
            catch
            {
                return other;
            }
        }
        public static bool ToOrOther<T>
                                 (this IConvertible obj,
                                 out T newObj,
                                 T other)
        {
            try
            {
                newObj = To<T>(obj);
                return true;
            }
            catch
            {
                newObj = other;
                return false;
            }
        }
        public static T ToOrNull<T>
                              (this IConvertible obj)
                              where T : class
        {
            try
            {
                return To<T>(obj);
            }
            catch
            {
                return null;
            }
        }
        public static bool ToOrNull<T>
                          (this IConvertible obj,
                          out T newObj)
                          where T : class
        {
            try
            {
                newObj = To<T>(obj);
                return true;
            }
            catch
            {
                newObj = null;
                return false;
            }
        }
