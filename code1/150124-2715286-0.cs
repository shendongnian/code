        public static IEnumerable<PropertyInfo> GetAllProperties(Type t)
        {
            while (t != typeof(object))
            {
                foreach (var prop in t.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
                    yield return prop;
                t = t.BaseType;
            }
        }
