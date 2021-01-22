    public static void ReplaceEmptyStrings<T>(List<T> list, string replacement)
    {
        PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo p in properties)
        {
            // Only work with strings
            if (p.PropertyType != typeof(string)) { continue; }
            // If not writable then cannot null it; if not readable then cannot check it's value
            if (!p.CanWrite || !p.CanRead) { continue; }
            MethodInfo mget = p.GetGetMethod(false);
            MethodInfo mset = p.GetSetMethod(false);
            // Get and set methods have to be public
            if (mget == null) { continue; }
            if (mset == null) { continue; }
            foreach (T item in list)
            {
                if (string.IsNullOrEmpty((string)p.GetValue(item, null)))
                {
                    p.SetValue(item, replacement, null);
                }
            }
        }
    }
