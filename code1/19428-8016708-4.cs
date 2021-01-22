    public List<MethodInfo> GetExtensionMethodsOf(Type t)
    {
        List<MethodInfo> methods = new List<MethodInfo>();
        Type cur = t;
        while (cur != null)
        {
            TypeInfo tInfo;
            if (typeInfo.TryGetValue(cur.GUID, out tInfo))
                methods.AddRange(tInfo.ExtensionMethods);
            foreach (var iface in cur.GetInterfaces())
            {
                if (typeInfo.TryGetValue(iface.GUID, out tInfo))
                    methods.AddRange(tInfo.ExtensionMethods);
            }
            cur = cur.BaseType;
        }
        return methods;
    }
