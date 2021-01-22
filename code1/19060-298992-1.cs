    private static Assembly a = typeof(IFactoryObject).Assembly;
    public static IFactoryObject CreateObject(String providerName)
    {
        Type t = a.GetType(providerName)
        IFactoryObject o = Activator.CreateInstance(t) as IFactoryObject;
        return o;
    }
