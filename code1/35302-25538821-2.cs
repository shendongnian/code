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
    public static string StripStartingWith(this string s, string stripAfter)
    {
        if (s == null)
        {
            return null;
        }
        var indexOf = s.IndexOf(stripAfter, StringComparison.Ordinal);
        if (indexOf > -1)
        {
            return s.Substring(0, indexOf);
        }
        return s;
    }
