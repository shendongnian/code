    private static void CopyClass<T>(T copyFrom, T copyTo, bool copyChildren)
    {
        if (copyFrom == null || copyTo == null)
            throw new Exception("Must not specify null parameters");
     
        var properties = copyFrom.GetType().GetProperties();
     
        foreach (var p in properties.Where(prop => prop.CanRead && prop.CanWrite))
        {
            if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
            {
                if (!copyChildren) continue;
     
                var destinationClass = Activator.CreateInstance(p.PropertyType);
                object copyValue = p.GetValue(copyFrom);
     
                CopyClass(copyValue, destinationClass, copyChildren);
     
                p.SetValue(copyTo, destinationClass);                  
            }
            else
            {
                object copyValue = p.GetValue(copyFrom);
                p.SetValue(copyTo, copyValue);
            }
        }
    }
