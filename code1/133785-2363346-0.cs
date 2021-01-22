    public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
    {
        StandardValuesCollection ret;
        Type tpProperty = context.PropertyDescriptor.PropertyType;
    
        if (tpProperty == typeof(bool))
            ret = new StandardValuesCollection(new object[] { true, false });
        else if (tpProperty == typeof(bool?))
            ret = new StandardValuesCollection(new object[] { true, false, null });
        else
            ret = new StandardValuesCollection(new object[0]);
    
        return ret;
    }
