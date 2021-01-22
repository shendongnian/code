    public static T CloneObject<T>(this T source)
    {
        if (source == null || source.GetType().IsSimple())
            return source;
        object clonedObj = Activator.CreateInstance(source.GetType());
        var properties = source.GetType().GetProperties();
        foreach (var property in properties)
        {
            try
            {
                property.SetValue(clonedObj, property.GetValue(source));
            }
            catch { }
        }
        return (T)clonedObj;
    }
	public static bool IsSimple(this Type type)
    {
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            // nullable type, check if the nested type is simple.
            return IsSimple(type.GetGenericArguments()[0]);
        }
        return !type.IsClass
          || type.IsPrimitive
          || type.IsEnum
          || type.Equals(typeof(string))
          || type.Equals(typeof(decimal));
    }
