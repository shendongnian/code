    public static string GetCSharpTypeName(this Type type, bool getFullName)
    {
        StringBuilder sb = new StringBuilder();
        if (getFullName && !string.IsNullOrEmpty(type.Namespace))
        {
            sb.Append(type.Namespace);
            sb.Append(".");
        }
        AppendCSharpTypeName(sb, type, getFullName);
        return sb.ToString();
    }
    
    private static void AppendCSharpTypeName
        (StringBuilder sb, Type type, bool fullParameterNames)
    {
        string typeName = type.Name;
        Type declaringType = type.DeclaringType;
    
        int declaringTypeArgumentCount = 0;
        if (type.IsNested)
        {
            if (declaringType.IsGenericTypeDefinition)
            {
                declaringTypeArgumentCount = 
                    declaringType.GetGenericArguments().Length;
                declaringType = declaringType.MakeGenericType(
                    type.GetGenericArguments().Take(declaringTypeArgumentCount)
                        .ToArray());
            }
    
            AppendCSharpTypeName(sb, declaringType, fullParameterNames);
            sb.Append(".");
        }
        Type[] genericArguments = type.GetGenericArguments()
            .Skip(declaringTypeArgumentCount).ToArray();
    
        int stopIndex;
        if ((type.IsGenericTypeDefinition || type.IsGenericType)
            && ((stopIndex = type.Name.IndexOf('`')) > 0))
        {
            sb.Append(typeName.Substring(0, stopIndex));
            string[] genericArgumentNames = genericArguments
                .Select(t => GetCSharpTypeName(t, fullParameterNames)).ToArray();
            if (genericArgumentNames.Length > 0)
                sb.AppendFormat("<{0}>", string.Join(",", genericArgumentNames));
        }
        else
        {
            sb.Append(typeName);
        }
    }
