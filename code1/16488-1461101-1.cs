    public static void SetProperty(Object R, string propertyName, object value)
    {
        Type type = R.GetType();
        object result;
        result = type.InvokeMember(
            propertyName, 
            BindingFlags.SetProperty | 
            BindingFlags.IgnoreCase | 
            BindingFlags.Public | 
            BindingFlags.Instance, 
            null, 
            R, 
            new object[] { value });
    }
