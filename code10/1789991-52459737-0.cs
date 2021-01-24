    var value = dr[column.ColumnName];
    
    if (pro.PropertyType == typeof(Enum) || pro.PropertyType.BaseType == typeof(Enum))
    {
        pro.SetValue(obj, Enum<StringComparison>.ToObject(value), null);
    }  
    else if(prop.PropertyType().IsAssignableFrom(value.GetType())
    {
        pro.SetValue(obj, value);
    }
    else
    {
        var typeConverter = TypeDescriptor.GetConverter(pro.PropertyType);
        pro.SetValue(obj, typeConverter.ConvertFrom(value), null);
    }   
