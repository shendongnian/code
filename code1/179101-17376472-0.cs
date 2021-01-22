    public static string CSharpName(this Type type)
    {
        var sb = new StringBuilder();
        var name = type.Name;
        if (!type.IsGenericType) return name;
        sb.Append(name.Substring(0, name.IndexOf('`')));
        sb.Append("<");
        sb.Append(string.Join(", ", type.GetGenericArguments()
                                        .Select(t => t.CSharpName())));
        sb.Append(">");
        return sb.ToString();
    }
