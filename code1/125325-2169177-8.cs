    public void Validate(object o)
    {
        Type t = o.GetType();
        foreach (var prop in
            t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            if (Attribute.IsDefined(prop, typeof(RequiredAttribute)))
            {
                object value = prop.GetValue(o, null);
                if (value == null)
                    throw new RequiredFieldException(prop.Name);
            }
        }
    }
