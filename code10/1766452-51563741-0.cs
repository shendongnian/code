    subscriberTypeToTopicKeySelector = iType =>
    {
        var instance = kernel.Get(iType);
        var classType = instance.GetType();
        var interfaceMap = classType.GetInterfaceMap(iType);
        var iTopicKeyPropertyGetMethods = iType.GetProperties()
                                               .Where(x => x.HasAttribute<TopicKeyAttribute>())
                                               .Select(x => x.GetMethod);
        var iTopicKeyMethods = iType.GetMethods()
                                    .Where(x => x.HasAttribute<TopicKeyAttribute>())
                                    .Union(iTopicKeyPropertyGetMethods);
        var indexOfInterfaceMethod = Array.IndexOf(interfaceMap.InterfaceMethods, iTopicKeyMethods.Single());
        var classMethodInfo = interfaceMap.TargetMethods[indexOfInterfaceMethod];
        return classMethodInfo.Invoke(instance, BindingFlags.Default, null, null, CultureInfo.CurrentCulture)
                              .ToString();
    };
