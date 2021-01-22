    public static class ReflectionMethods
    {
        public static bool IsNonStringEnumerable(this PropertyInfo pi)
        {
            return pi != null && pi.PropertyType.IsNonStringEnumerable();
        }
        public static bool IsNonStringEnumerable(this object instance)
        {
            return instance != null && instance.GetType().IsNonStringEnumerable();
        }
        public static bool IsNonStringEnumerable(this Type type)
        {
            if (type == null || type == typeof(string))
                return false;
            return typeof(IEnumerable).IsAssignableFrom(type);
        }
        public static Object GetPropValue(String name, Object obj)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }
                if (obj.IsNonStringEnumerable())
                {
                    var toEnumerable = (IEnumerable)obj;
                    var iterator = toEnumerable.GetEnumerator();
                    if (!iterator.MoveNext())
                    {
                        return null;
                    }
                    obj = iterator.Current;
                }
                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }
                obj = info.GetValue(obj, null);
            }
            return obj;
        }
    }
