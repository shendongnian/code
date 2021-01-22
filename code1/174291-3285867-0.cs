    Type interfaceType = typeof(IEmployee);
    Type classType = typeof(Employee);
    PropertyInfo nameProperty = interfaceType.GetProperty("Name");
    MethodInfo nameGetter = nameProperty.GetGetMethod();
    InterfaceMapping mapping = classType.GetInterfaceMap(interfaceType);
    MethodInfo targetMethod = null;
    for (int i = 0; i < mapping.InterfaceMethods.Length; i++)
    {
        if (mapping.InterfaceMethods[i] == nameGetter)
        {
            targetMethod = mapping.TargetMethods[i];
            break;
        }
    }
    PropertyInfo targetProperty = null;
    foreach (PropertyInfo property in classType.GetProperties(
        BindingFlags.Instance | BindingFlags.GetProperty | 
        BindingFlags.Public | BindingFlags.NonPublic))   // include non-public!
    {
        if (targetMethod == property.GetGetMethod(true)) // include non-public!
        {
            targetProperty = property;
            break;
        }
    }
    // targetProperty is the actual property
