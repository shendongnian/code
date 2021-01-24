    public static bool CheckObjectForNullProperties<T>(T obj)
    {
        foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
        {
            if (propertyInfo.GetValue(obj) == null)
            {
                return false;
            }
        }
        return true;
    }
