    public object GetDefaultValue(Type t)
    {
        if (t.IsValueType)
        {
            return Activator.CreateInstance(t);
        }
        else
        {
            return null;
        }
    }
