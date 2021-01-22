    public static string GetPropertyName([System.Runtime.CompilerServices.CallerMemberName] String propertyName = "")
    {
        return propertyName;
    }
    public static Object TestName
    {
        get {
            return X(GetPropertyName());
        }
    }
