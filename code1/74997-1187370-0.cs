    public void SaveOrUpdateDomainObject(object domainObject, string typeName)
    {
        Type T = Type.GetType(typeName);
        MethodInfo genericMethod = domainRoot.GetType().GetMethod("SaveDomainObject");
        MethodInfo method = genericMethod.MakeGenericMethod(T);
        method.Invoke(domainRoot, domainObject);
    }
