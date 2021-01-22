    public static void SaveToOriginal<T>(this T original, T actual)
        {
            foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(info => info.GetCustomAttribute<System.Data.Linq.Mapping.ColumnAttribute>() != null))
            {
                prop.SetValue(original, prop.GetValue(actual));
            }
        }
