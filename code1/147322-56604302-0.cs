    public static object GetAttributeValue<TAttribute, TValue>(this object val, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
    {
        try
        {
            Type t = val.GetType();
            TAttribute attr;
            if (t.IsEnum && t.GetField(val.ToString()).GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute att)
            {
                // Applies to Enum values
                attr = att;
            }
            else if (val is PropertyInfo pi && pi.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute piAtt)
            {
                // Applies to Properties in a Class
                attr = piAtt;
            }
            else
            {
                // Applies to classes
                attr = (TAttribute)t.GetCustomAttributes(typeof(TAttribute), false).FirstOrDefault();
            }
            return valueSelector(attr);
        }
        catch
        {
            return null;
        }
    }
