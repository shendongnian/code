    internal static Type GetElementType(this Type type)
    {
            //use type.GenericTypeArguments if exist 
            if (type.GenericTypeArguments.Any())
             return type.GenericTypeArguments.First()
             return type.GetRuntimeProperty("Item").PropertyType)
    }
