    public static object CloneObject(object opSource)
    {
        //grab the type and create a new instance of that type
        Type opSourceType = opSource.GetType();
        object opTarget = CreateInstanceOfType(opSourceType);
        //grab the properties
        PropertyInfo[] opPropertyInfo = opSourceType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        //iterate over the properties and if it has a 'set' method assign it from the source TO the target
        foreach (PropertyInfo item in opPropertyInfo)
        {
            if (item.CanWrite)
            {
                //value types can simply be 'set'
                if (item.PropertyType.IsValueType || item.PropertyType.IsEnum || item.PropertyType.Equals(typeof(System.String)))
                {
                    item.SetValue(opTarget, item.GetValue(opSource, null), null);
                }
                //object/complex types need to recursively call this method until the end of the tree is reached
                else
                {
                    object opPropertyValue = item.GetValue(opSource, null);
                    if (opPropertyValue == null)
                    {
                        item.SetValue(opTarget, null, null);
                    }
                    else
                    {
                        item.SetValue(opTarget, CloneObject(opPropertyValue), null);
                    }
                }
            }
        }
        //return the new item
        return opTarget;
    }
