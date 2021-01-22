    public string ToGenericTypeString(Type t)
    {
        if (!t.IsGenericType)
            return t.FullName;
        string genericTypeName = t.GetGenericTypeDefinition().FullName;
        genericTypeName = genericTypeName.Substring(0,
            genericTypeName.IndexOf('`'));
        string genericArgs = string.Join(",",
            t.GetGenericArguments()
                .Select(ta => ToGenericTypeString(ta)).ToArray());
        return genericTypeName + "<" + genericArgs + ">";
    }
