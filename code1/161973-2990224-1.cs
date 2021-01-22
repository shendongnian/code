    public void SetDefaultValues()
    {
        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
        {
            DefaultValueAttribute a = prop.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
            if (a == null) 
                continue;
            prop.SetValue(this, a.Value);
        }
    }
