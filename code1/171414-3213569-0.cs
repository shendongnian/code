    [ComVisible(true)]
    public static Array GetValues(Type enumType)
    {
        if (enumType == null)
        {
            throw new ArgumentNullException("enumType");
        }
        if (!(enumType is RuntimeType))
        {
            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
        }
        if (!enumType.IsEnum)
        {
            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
        }
        ulong[] values = GetHashEntry(enumType).values;
        Array array = Array.CreateInstance(enumType, values.Length);
        for (int i = 0; i < values.Length; i++)
        {
            object obj2 = ToObject(enumType, values[i]);
            array.SetValue(obj2, i);
        }
        return array;
    }
