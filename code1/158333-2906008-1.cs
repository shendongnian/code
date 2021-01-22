    public object this[string propertyName]
    {
        get
        {
            PropertyInfo property = GetType().GetProperty(propertyName);
            return property.GetValue(this, null);
        }
        set
        {
            PropertyInfo property = GetType().GetProperty(propertyName);
            property.SetValue(this,value, null);
        }
    }
