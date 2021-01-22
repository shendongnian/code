    else 
    {
        if (getMethod.IsHideBySig)
        {
            var flags = getMethod.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic;
            flags |= getMethod.IsStatic ? BindingFlags.Static : BindingFlags.Instance;
            var paramTypes = getMethod.GetParameters().Select(p => p.ParameterType).ToArray();
            if (getMethod.DeclaringType.BaseType.GetMethod(getMethod.Name, flags, null, paramTypes, null) != null)
            {
                // the property's 'get' method shadows by signature
            }
        }
        else
        {
            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            if (getMethod.DeclaringType.BaseType.GetMethods(flags).Any(m => m.Name == getMethod.Name))
            {
                // the property's 'get' method shadows by name
            }
        }
    }
