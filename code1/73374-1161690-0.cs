    public static object GetValue(object obj, string propertyName)
    {
        return RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj, null,
             propertyName, new object[0], null, null, null));
    }
