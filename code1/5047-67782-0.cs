    string typeName = ...;
    Type proxyType = Type.GetType(typeName);
    
    Type type = typeof (ChannelFactory<>).MakeGenericType(proxyType);
    
    object target = Activator.CreateInstance(type);
    
    MethodInfo methodInfo = type.GetMethod("CreateChannel", new Type[] {});
    
    return methodInfo.Invoke(target, new object[0]);
