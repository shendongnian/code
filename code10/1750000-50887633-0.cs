    public object this[string className, string propertyName]
    {
        get
        {
            var innerClass = GetType().GetNestedType(className);
            PropertyInfo myPropInfo = innerClass?.GetProperty(propertyName);
            return myPropInfo?.GetValue(this, null);
        }
        set
        {
            var innerClass = GetType().GetNestedType(className);
            PropertyInfo myPropInfo = innerClass?.GetProperty(propertyName);
            myPropInfo?.SetValue(this, value, null);
        }
    }
