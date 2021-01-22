    public static string GetFriendlyTypeName(this Type t)
    {
        var typeName = t.Name.StripStartingWith("`");
        var genericArgs = t.GetGenericArguments();
        if (genericArgs.Length > 0)
        {
            typeName += "<";
            foreach (var genericArg in genericArgs)
            {
                typeName += genericArg.GetFriendlyTypeName() + ", ";
            }
            typeName = typeName.TrimEnd(',', ' ') + ">";
        }
        return typeName;
    }
