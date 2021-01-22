    Type ifaceType = typeof(TempInterface);
    Type tempType = typeof(TempClass);
    InterfaceMapping map = tempType.GetInterfaceMap(ifaceType);
    for (int i = 0; i < map.InterfaceMethods.Length; i++)
    {
        MethodInfo ifaceMethod = map.InterfaceMethods[i];
        MethodInfo targetMethod = map.TargetMethods[i];
        Debug.WriteLine(String.Format("{0} maps to {1}", ifaceMethod, targetMethod));
    }
