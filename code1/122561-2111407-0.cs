    private InterfaceMap interfaceMethods = typeof(YourClass).GetInterfaceMap(typeof(YourInterface));
    public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
    {
       return Array.IndexOf(interfaceMethods.ClassMethods,methodInfo)!=-1;
    }
 
